using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.Migrations;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LibraryController : ControllerBase
    {
        private ILibraryServices _library {  get; set; }
        public LibraryController(ILibraryServices libraryServices)
        {
           _library = libraryServices;
        }

        [HttpPost("Add Game to Library")]
        public async Task<ActionResult<ServiceResponse<GetLibraryGameDetailDTO>>> AddToLibrary (AddLibraryGameDTO gameDetails)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _library.AddGameToLibrary(gameDetails, userId));
        }

        [HttpPost("My Games")]
        public async Task<ActionResult<ServiceResponse<List<GetLibraryGameDetailDTO>>>> GetMyGames()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _library.GetGamesFromLibrary(userId));
        }

        [HttpPost("My Top Ranked Games")]
        public async Task<ActionResult<ServiceResponse<List<GetLibraryGameDetailDTO>>>> GetMyTop5()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _library.MyTopRatedGames(userId));
        }


    }
}
