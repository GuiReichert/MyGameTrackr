using MyGameTrackr.DTO_s.PublicReviewsDTO_s;
using MyGameTrackr.Models;

namespace MyGameTrackr.Services
{
    public interface IGameService
    {
        public void ProcessOverallScore(Game_Model game);
        public void AddGameToDb(int APIGameId, string gameName);
        public Task<ServiceResponse<GetPublicGameReviewsDTO>> GetGamePublicReviews(int APIGameId);
        public Task<ServiceResponse<List<GetPublicGameReviewsDTO>>> TopRankedGames();


    }
}
