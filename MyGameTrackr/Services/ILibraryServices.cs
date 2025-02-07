using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public interface ILibraryServices
    {
        public Task<ServiceResponse<GetLibraryGameDetailDTO>> AddGameToLibrary(GetLibraryGameDetailDTO request);
        public Task<ServiceResponse<GetLibraryGameDetailDTO>> UpdateGameInLibrary(GetLibraryGameDetailDTO request);

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> DeleteGameFromLibrary(int APIGameId);
        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> GetGamesFromLibrary();

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> MyTopRatedGames();
    }
}
