using MyGameTrackr.DTO_s;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public interface ILibraryServices
    {
        public Task<ServiceResponse<GetLibraryGameDetailDTO>> AddGameToLibrary(AddLibraryGameDTO request, int userId);
        public Task<ServiceResponse<GetLibraryGameDetailDTO>> UpdateGameInLibrary(GetLibraryGameDetailDTO request, int userId);

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> DeleteGameFromLibrary(int APIGameId, int userId);
        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> GetGamesFromLibrary(int userId);

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> MyTopRatedGames(int userId);
    }
}
