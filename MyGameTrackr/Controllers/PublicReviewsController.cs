using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s.PublicReviewsDTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{
    [ApiController]
    [Route("games/public-reviews")]
    public class PublicReviewsController : ControllerBase
    {
        private IGameService _gameservice;

        public PublicReviewsController(IGameService gameService)
        {
            _gameservice = gameService;
        }

        [HttpGet("game/{Id}")]
        public async Task<ActionResult<ServiceResponse<GetPublicGameReviewsDTO>>> GetGamePublicReviews(int Id)
        {
            return Ok(await _gameservice.GetGamePublicReviews(Id));
        }

        [HttpGet("top-ranked-games")]
        public async Task<ActionResult<ServiceResponse<List<GetPublicGameReviewsDTO>>>> GetTopRankedGames()
        {
            return Ok(await _gameservice.TopRankedGames());
        }

    }
}
