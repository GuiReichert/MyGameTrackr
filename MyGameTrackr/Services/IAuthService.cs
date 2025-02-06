using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;

namespace MyGameTrackr.Services
{
    public interface IAuthService
    {
         Task<ServiceResponse<string>> Register(string Username, string Password);
         Task<ServiceResponse<string>> Login(string Username, string Password);
         Task<bool> UserExists(string username);
    }
}
