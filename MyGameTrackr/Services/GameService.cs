using Microsoft.EntityFrameworkCore;
using MyGameTrackr.Database;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.DTO_s.PublicReviewsDTO_s;
using MyGameTrackr.Models;

namespace MyGameTrackr.Services
{
    public class GameService : IGameService
    {
        private MyGameTrackr_Context db;
        private ISearchGames _searchGames;

        public GameService(MyGameTrackr_Context db, ISearchGames searchGames)
        {
            this.db = db;
            _searchGames = searchGames;
        }


        public Task<ServiceResponse<GetPublicGameReviewsDTO>> GetGamePublicReviews(int APIGameId)
        {
            throw new NotImplementedException();
        }


        public Task<ServiceResponse<GetPublicGameReviewsDTO>> TopRankedGames()
        {
            throw new NotImplementedException();
        }









        public void AddGameToDb(int APIGameId, string gameName)
        {

            var game =  db.Games.FirstOrDefault(x=> x.APIGameId == APIGameId);
            if (game == null)
            {
                var newGame = new Game_Model
                {
                    APIGameId = APIGameId,
                    GameName = gameName
                };

                db.Games.Add(newGame);
                db.SaveChanges();
            }

        }



        public void ProcessOverallScore(Game_Model game)
        {
            var PublicReviews = db.GameReviews.Where(x=> x.Game_ModelId == game.Id && !x.isAnonymousReview).ToList();

            if (PublicReviews.Count == 0)
            {
                game.OverallScore = 0;
            }
            else
            {
                game.OverallScore = (float)PublicReviews.Average(x => x.Score);
            }
            db.SaveChanges();






        }

    }
}
