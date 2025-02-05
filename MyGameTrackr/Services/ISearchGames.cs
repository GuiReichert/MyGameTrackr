using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;

namespace MyGameTrackr.Services
{
    public interface ISearchGames
    {
        public Task<ServiceResponse<GetGameDetailDTO>> FindGameByName(string gameName);
        public Task<ServiceResponse<GetGameDetailDTO>> FindGameById(int  id);
    }
}
