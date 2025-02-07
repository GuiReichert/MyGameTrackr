using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;

namespace MyGameTrackr.Services
{
    public interface ISearchGames
    {
        public Task<ServiceResponse<GetAPIGameDetailDTO>> FindGameByName(string gameName);
        public Task<ServiceResponse<GetAPIGameDetailDTO>> FindGameById(int  id);
    }
}
