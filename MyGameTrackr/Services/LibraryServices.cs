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

        public LibraryServices(MyGameTrackr_Context db, IMapper mapper, ISearchGames gamesearch)
        {
            this.db = db;
            _mapper = mapper;
            _gameSearch = gamesearch;
        }




        public async Task<ServiceResponse<GetLibraryGameDetailDTO>> AddGameToLibrary(AddLibraryGameDTO request, int userId)
        {
            var response = new ServiceResponse<GetLibraryGameDetailDTO>();

            try
            {
                var userLibrary = await db.UserLibraries.Include(x => x.Games).FirstOrDefaultAsync(x => x.User_ModelId == userId);
                var searchAPI = await _gameSearch.FindGameById(request.APIGameId);

                if (!searchAPI.Success)
                {
                    throw new Exception("Could not fetch data for this game from API. The Id inputted might be incorrect.");
                }


                if (await db.UserGames.FirstOrDefaultAsync(x=> x.APIGameId == request.APIGameId && x.UserLibrary == userLibrary) != null)
                {
                    throw new Exception("You already added this game to your library.");
                }
                if (request.Score >10 || request.Score < 0)
                {
                    throw new Exception("You must provide a score between 0 and 10.");
                }
                if (!Enum.IsDefined(typeof(GameState), request.CurrentState) || !Enum.TryParse<GameState>(request.CurrentState, true,out var parsedCurrentState))
                {
                    throw new Exception("Invalid game state. You must choose a state between: Wishlist, Purchased, Dropped, or Played.");
                }


                var newGame = new LibraryGames_Model()
                {
                    UserLibrary = userLibrary,
                    APIGameId = request.APIGameId,
                    GameName = searchAPI.Data.Name,
                    CurrentState = parsedCurrentState,
                    Score = request.Score,
                    LastStateUpdated = DateTime.Now.ToString("G"),
                    Comment = request.Comment
                };

                userLibrary.Games.Add(newGame);
                await db.SaveChangesAsync();

                response.Data = _mapper.Map<GetLibraryGameDetailDTO>(newGame);
                


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> DeleteGameFromLibrary(int APIGameId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> GetGamesFromLibrary(int userId)
        {
            var response = new ServiceResponse<List<GetLibraryGameDetailDTO>>();
            try
            {
                var library = await db.UserLibraries.Include(x=> x.Games).FirstOrDefaultAsync(x => x.User_ModelId == userId);
                var gameList = _mapper.Map<List<GetLibraryGameDetailDTO>>(library!.Games);
                response.Data = gameList.OrderBy(x=> x.APIGameId).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> MyTopRatedGames(int userId)
        {
            var response = new ServiceResponse<List<GetLibraryGameDetailDTO>>();
            try
            {
                var library = await db.UserLibraries.Include(x => x.Games).FirstOrDefaultAsync(x => x.User_ModelId == userId);
                var gameList = _mapper.Map<List<GetLibraryGameDetailDTO>>(library!.Games);
                response.Data = gameList.OrderBy(x => x.Score).Take(5).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLibraryGameDetailDTO>> UpdateGameInLibrary(GetLibraryGameDetailDTO request, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
