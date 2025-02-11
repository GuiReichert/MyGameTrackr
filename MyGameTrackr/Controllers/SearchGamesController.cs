using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{

    [ApiController]
    [Route("search-games")]
    public class SearchGamesController : ControllerBase
    {
        private ISearchGames _searchgames;

        public SearchGamesController(ISearchGames searchGames)
        {
            _searchgames = searchGames;
        }

        [HttpGet("details/id/{Id}")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsById(int Id)
        {
            var response = await _searchgames.FindGameById(Id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("details/name/{Game_Name}")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsByName(string Game_Name)
        {
            var response = await _searchgames.FindGameByName(Game_Name);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


    }
}
