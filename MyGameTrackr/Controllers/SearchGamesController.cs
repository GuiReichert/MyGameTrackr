using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SearchGamesController : ControllerBase
    {
        private ISearchGames _searchgames;

        public SearchGamesController(ISearchGames searchGames)
        {
            _searchgames = searchGames;
        }

        [HttpGet("Find Game by Id")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsById(int Id)
        {
            return Ok(await _searchgames.FindGameById(Id));
        }

        [HttpGet("Find Game by Name")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsByName(string Game_Name)
        {
            return Ok(await _searchgames.FindGameByName(Game_Name));
        }


    }
}
