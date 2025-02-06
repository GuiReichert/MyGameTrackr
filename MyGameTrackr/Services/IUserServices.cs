using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public interface IUserServices
    {
        public Task<ServiceResponse<UserGames_Model>> AddGameToLibrary(UserGames_Model request);
        public Task<ServiceResponse<UserGames_Model>> UpdateGameInLibrary(UserGames_Model request);

        public Task<ServiceResponse<UserGames_Model>> DeleteGameFromLibrary(UserGames_Model request);
        public Task<ServiceResponse<List<UserGames_Model>>> GetGamesFromLibrary();

        public Task<ServiceResponse<List<UserGames_Model>>> MyTopRatedGames();
    }
}
