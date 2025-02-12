using Azure;
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

        [HttpGet("game/{id}")]
        public async Task<ActionResult<ServiceResponse<GetPublicGameReviewsDTO>>> GetGamePublicReviews(int id)
        {
            var response = await _gameservice.GetGamePublicReviews(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("top-rated-games")]
        public async Task<ActionResult<ServiceResponse<List<GetPublicGameReviewsDTO>>>> GetTopRankedGames()
        {
            var response = await _gameservice.TopRankedGames();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
