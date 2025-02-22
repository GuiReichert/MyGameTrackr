using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private Services.IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }
        

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(string Username, string Password)
        {
            var response = await _authService.Register(Username,Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(string username, string password)
        {
            var response = await _authService.Login(username, password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



    }
}
