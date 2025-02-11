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
                    LastStateUpdated = DateTime.Now
                };


                db.GameReviews.Add(newReview);
                await db.SaveChangesAsync();


                    _gameService.ProcessOverallScore(game);


                response.Data = new GetLibraryGameReviewDTO
                {
                    GameName = game.GameName,
                    CurrentState = parsedCurrentState,
                    LastStateUpdated = newReview.LastStateUpdated.ToString("G"),
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
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> GetGamesFromLibrary(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> MyTopRatedGames(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetLibraryGameReviewDTO>> UpdateGameInLibrary(AddLibraryGameReviewDTO request, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
