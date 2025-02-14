using System.Security.Claims;
using Azure;
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
    [Route("user-library")]
    [Authorize]
    public class LibraryController : ControllerBase
    {
        private ILibraryServices _library {  get; set; }
        public LibraryController(ILibraryServices libraryServices)
        {
           _library = libraryServices;
        }

        [HttpPost("games")]
        public async Task<ActionResult<ServiceResponse<GetLibraryGameReviewDTO>>> AddToLibrary (AddLibraryGameReviewDTO request)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            var response = await _library.AddGameToLibrary(request, userId);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("games/all")]
        public ActionResult<ServiceResponse<List<GetLibraryGameReviewDTO>>> GetMyGames()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            var response =  _library.GetGamesFromLibrary(userId);
            

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("games/my-top-5")]
        public ActionResult<ServiceResponse<List<GetLibraryGameReviewDTO>>> GetMyTop5()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            var response = _library.MyTopRatedGames(userId);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpDelete("games/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetLibraryGameReviewDTO>>>> DeleteFromLibrary(int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
            var response = await _library.DeleteGameFromLibrary(id, userId);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPut("games")]
        public async Task<ActionResult<ServiceResponse<GetLibraryGameReviewDTO>>> UpdateGameInLibrary(AddLibraryGameReviewDTO request)
        {
            int userId = int.Parse((User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.NameIdentifier))!.Value);
            var response = await _library.UpdateGameInLibrary(request, userId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }



    }
}
