using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public class UserServices : IUserServices
    {
        public Task<ServiceResponse<UserGames_Model>> AddGameToLibrary(UserGames_Model request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserGames_Model>> DeleteGameFromLibrary(UserGames_Model request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserGames_Model>>> GetGamesFromLibrary()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserGames_Model>>> MyTopRatedGames()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserGames_Model>> UpdateGameInLibrary(UserGames_Model request)
        {
            throw new NotImplementedException();
        }
    }
}
