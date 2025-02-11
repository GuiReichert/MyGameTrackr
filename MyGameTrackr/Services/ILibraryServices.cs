using MyGameTrackr.DTO_s;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public interface ILibraryServices
    {
        public Task<ServiceResponse<GetLibraryGameReviewDTO>> AddGameToLibrary(AddLibraryGameReviewDTO request, int userId);
        public Task<ServiceResponse<GetLibraryGameReviewDTO>> UpdateGameInLibrary(AddLibraryGameReviewDTO request, int userId);

        public Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> DeleteGameFromLibrary(int APIGameId, int userId);
        public Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> GetGamesFromLibrary(int userId);

        public Task<ServiceResponse<List<GetLibraryGameReviewDTO>>> MyTopRatedGames(int userId);
    }
}
