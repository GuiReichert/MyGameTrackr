using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public class LibraryServices : ILibraryServices
    {
        public Task<ServiceResponse<GetLibraryGameDetailDTO>> AddGameToLibrary(GetLibraryGameDetailDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> DeleteGameFromLibrary(int APIGameId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> GetGamesFromLibrary()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetLibraryGameDetailDTO>>> MyTopRatedGames()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetLibraryGameDetailDTO>> UpdateGameInLibrary(GetLibraryGameDetailDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
