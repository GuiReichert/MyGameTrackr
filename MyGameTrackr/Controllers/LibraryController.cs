using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
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
        public async Task<ActionResult<ServiceResponse<GetLibraryGameDetailDTO>>> AddToLibrary (GetLibraryGameDetailDTO libraryGameDetailDTO)
        {
            return Ok(await _library.AddGameToLibrary(libraryGameDetailDTO));
        }
    }
}
