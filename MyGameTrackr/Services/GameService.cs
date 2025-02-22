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


        public async Task<ServiceResponse<GetPublicGameReviewsDTO>> GetGamePublicReviews(int APIGameId)
        {
            var response = new ServiceResponse<GetPublicGameReviewsDTO>();
            try
            {
                var game = await db.Games.FirstOrDefaultAsync(game => game.APIGameId == APIGameId);
                if (game == null)
                {
                    throw new Exception("This game has not been added to any libraries yet.");
                }
                var gameReviews = await db.GameReviews.Include(review => review.Game_Model).Include(review => review.UserLibrary).ThenInclude(library => library.User).Where(review => review.Game_Model.APIGameId == APIGameId && !review.isAnonymousReview).OrderByDescending(review => review.LastUpdate).ToListAsync();
                if (gameReviews.Count == 0)
                {
                    throw new Exception("This game has no public reviews yet.");
                }

                GetPublicGameReviewsDTO reviewDTO = MapPublicGameReviews(game, gameReviews);

                response.Data = reviewDTO;


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public async Task<ServiceResponse<List<GetPublicGameReviewsDTO>>> TopRankedGames()
        {
            var response = new ServiceResponse<List<GetPublicGameReviewsDTO>>();
            try
            {
                var topGames = await db.Games.Include(game => game.Reviews).ThenInclude(game => game.UserLibrary).ThenInclude(library => library.User).Where(game => game.OverallScore != 0).OrderByDescending(game => game.OverallScore).Take(10).ToListAsync();     //"Where" statement takes out of ALL games that ONLY HAVE anonymous reviews!
                var topGamesReviews = new List<GetPublicGameReviewsDTO>();

                foreach (var game in topGames)
                {
                    var gameReviews = game.Reviews.Where(reviews=> !reviews.isAnonymousReview).ToList();
                    var reviewsDTO = MapPublicGameReviews(game, gameReviews);
                    reviewsDTO.GameReviews = reviewsDTO.GameReviews.OrderByDescending(reviews => reviews.LastUpdate).Take(5).ToList();
                    topGamesReviews.Add(reviewsDTO);
                }

                response.Data = topGamesReviews;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }









        public void AddGameToDb(int APIGameId, string gameName)
        {

            var game =  db.Games.FirstOrDefault(game => game.APIGameId == APIGameId);
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
            var PublicReviews = db.GameReviews.Where(reviews=> reviews.Game_ModelId == game.Id && !reviews.isAnonymousReview && reviews.CurrentState != GameState.Wishlist).ToList();

            if (PublicReviews.Count == 0)
            {
                game.OverallScore = 0;
            }
            else
            {
                game.OverallScore = (float)PublicReviews.Average(review => review.Score);
            }
            db.SaveChanges();

        }


        private static GetPublicGameReviewsDTO MapPublicGameReviews(Game_Model? game, List<GameReview_Model> gameReviews)
        {
            var ReviewsDTO = new List<SingularGameReviewDTO>();

            foreach (var gameReview in gameReviews)
            {
                var singularReview = new SingularGameReviewDTO
                {
                    Username = gameReview.UserLibrary.User.Username,
                    Score = gameReview.Score,
                    CurrentState = gameReview.CurrentState,
                    LastUpdate = gameReview.LastUpdate.ToString("G"),
                    Comment = gameReview.Comment
                };
                ReviewsDTO.Add(singularReview);
            }


            var reviewDTO = new GetPublicGameReviewsDTO
            {
                GameName = game.GameName,
                OverallScore = game.OverallScore,
                GameReviews = ReviewsDTO
            };
            return reviewDTO;
        }






    }
}
