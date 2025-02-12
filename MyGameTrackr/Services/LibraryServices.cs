using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyGameTrackr.Database;
using MyGameTrackr.DTO_s;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public class LibraryServices : ILibraryServices
    {
        private MyGameTrackr_Context db;
        private IMapper _mapper;
        private ISearchGames _gameSearch;
        private IGameService _gameService;

        public LibraryServices(MyGameTrackr_Context db, IMapper mapper, ISearchGames gamesearch,IGameService gameService)
        {
            this.db = db;
            _mapper = mapper;
            _gameSearch = gamesearch;
            _gameService = gameService;
        }

        public async Task<ServiceResponse<GetLibraryGameReviewDTO>> AddGameToLibrary(AddLibraryGameReviewDTO request, int userId)
        {
            var response = new ServiceResponse<GetLibraryGameReviewDTO>();

            try
            {
                var userLibrary = await db.UserLibraries.Include(x => x.GamesReviews).ThenInclude(x=> x.Game_Model).FirstOrDefaultAsync(x=> x.User_ModelId == userId);
                var SearchAPI = await _gameSearch.FindGameById(request.APIGameId);
                if (!SearchAPI.Success)
                {
                    throw new Exception("Could not fetch data for this game from API. The Id inputted might be incorrect.");
                }
                _gameService.AddGameToDb(request.APIGameId, SearchAPI.Data!.Name);


                if (await db.GameReviews.FirstOrDefaultAsync(x => x.Game_Model.APIGameId == request.APIGameId && x.UserLibrary == userLibrary) != null)
                {
                    throw new Exception("You already added this game to your library.");
                }
                if (request.Score > 10 || request.Score < 0)
                {
                    throw new Exception("You must provide a score between 0 and 10.");
                }
                if (!Enum.IsDefined(typeof(GameState), request.CurrentState) || !Enum.TryParse<GameState>(request.CurrentState, true, out var parsedCurrentState))
                {
                    throw new Exception("Invalid game state. You must choose a state between: Wishlist, Purchased, Dropped, or Played.");
                }



                var game = await db.Games.FirstOrDefaultAsync(x=> x.APIGameId == request.APIGameId);
                var newReview = new GameReview_Model
                {
                    Game_Model = game!,
                    Game_ModelId = game!.Id,
                    UserLibrary = userLibrary!,
                    Score = request.Score,
                    Comment = request.Comment,
                    isAnonymousReview = request.isAnonymousReview,
                    CurrentState = parsedCurrentState,
                    LastUpdate = DateTime.Now
                };


                db.GameReviews.Add(newReview);
                await db.SaveChangesAsync();


                    _gameService.ProcessOverallScore(game);


                response.Data = new GetLibraryGameReviewDTO
                {
                    GameName = game.GameName,
                    CurrentState = parsedCurrentState,
                    LastUpdate = newReview.LastUpdate.ToString("G"),
                    Score = request.Score,
                    Comment = request.Comment
                };


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> DeleteGameFromLibrary(int APIGameId, int userId)
        {
            var response = new ServiceResponse<List<GetLibraryGameReviewDTO>>();
            try
            {
                var game = await db.GameReviews.Include(x => x.UserLibrary).Include(x => x.Game_Model).FirstOrDefaultAsync(x => x.UserLibrary.User_ModelId == userId && x.Game_Model.APIGameId == APIGameId);
                if (game == null)
                {
                    throw new Exception("This game is not in your library yet.");
                }

                db.GameReviews.Remove(game);
                await db.SaveChangesAsync();

                _gameService.ProcessOverallScore(game.Game_Model);

                response.Data = Map_List_GameReviewDTO(userId);



            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ServiceResponse<List<GetLibraryGameReviewDTO>> GetGamesFromLibrary(int userId)
        {
            var response = new ServiceResponse<List<GetLibraryGameReviewDTO>>();
            try
            {
                response.Data = Map_List_GameReviewDTO(userId).OrderByDescending(x=> x.LastUpdate).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ServiceResponse<List<GetLibraryGameReviewDTO>> MyTopRatedGames(int userId)
        {
            var response = new ServiceResponse<List<GetLibraryGameReviewDTO>>();
            try
            {
                response.Data = Map_List_GameReviewDTO(userId).OrderByDescending(x => x.Score).Take(5).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLibraryGameReviewDTO>> UpdateGameInLibrary(AddLibraryGameReviewDTO request, int userId)
        {
            var response = new ServiceResponse<GetLibraryGameReviewDTO>();
            try
            {
                var reviewToChange = await db.GameReviews.Include(x => x.Game_Model).FirstOrDefaultAsync(x => x.Game_Model.APIGameId == request.APIGameId && x.UserLibrary.User_ModelId == userId);
                if (reviewToChange == null)
                {
                    throw new Exception("This game is not in your library yet.");
                }

                if (request.Score < 0 || request.Score > 10)
                {
                    throw new Exception("You must provide a score between 0 and 10.");
                }
                if (!Enum.IsDefined(typeof(GameState),request.CurrentState)|| !Enum.TryParse<GameState>(request.CurrentState,true,out var parsedCurrentState))
                {
                    throw new Exception("Invalid game state. You must choose a state between: Wishlist, Purchased, Dropped, or Played.");
                }

                reviewToChange.LastUpdate = DateTime.Now;
                reviewToChange.isAnonymousReview = request.isAnonymousReview;
                reviewToChange.Score = request.Score;
                reviewToChange.Comment = request.Comment;
                reviewToChange.CurrentState = parsedCurrentState;

                await db.SaveChangesAsync();

                _gameService.ProcessOverallScore(reviewToChange.Game_Model);

                response.Data = new GetLibraryGameReviewDTO
                {
                    GameName = reviewToChange.Game_Model.GameName,
                    CurrentState = parsedCurrentState,
                    LastUpdate = reviewToChange.LastUpdate.ToString("G"),
                    Score = reviewToChange.Score,
                    Comment = reviewToChange.Comment
                };

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        private  List<GetLibraryGameReviewDTO> Map_List_GameReviewDTO(int userId)
        {
            var userReviews = db.GameReviews.Include(x => x.Game_Model).Where(x => x.UserLibrary.User_ModelId == userId).ToList();
            var userReviewsDTO = new List<GetLibraryGameReviewDTO>();

            foreach (var userReview in userReviews)
            {
                var review = new GetLibraryGameReviewDTO
                {
                    GameName = userReview.Game_Model.GameName,
                    CurrentState = userReview.CurrentState,
                    LastUpdate = userReview.LastUpdate.ToString("G"),
                    Score = userReview.Score,
                    Comment = userReview.Comment
                };
                userReviewsDTO.Add(review);
            }

            return userReviewsDTO;
        }

















    }
}
