using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyGameTrackr.Database;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Services
{
    public class AuthService : IAuthService
    {
        private MyGameTrackr_Context db;

        public AuthService(MyGameTrackr_Context db)
        {
            this.db = db;
        }


        public async Task<ServiceResponse<string>> Register(string Username, string Password)
        {
            var response = new ServiceResponse<string>();
            User_Model newUser= new User_Model();
            if (await UserExists(Username))
            {
                response.Success = false;
                response.Message = "This username is unavailable";
                return response; 
            }

                CreatePasswordHash(Password, out byte[] passwordHash, out byte[] passwordSalt);
                newUser.Username = Username;
                newUser.PasswordSalt = passwordSalt;
                newUser.PasswordHash = passwordHash;

                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                response.Data = "Account created successfully";
            
            return response;
        }

        public async Task<ServiceResponse<string>> Login(string Username, string Password)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var user = await db.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == Username.ToLower());
                if(user == null  || !VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Username or Password is incorrect");
                }
                response.Data = CreateToken(user);
            }
            catch (Exception ex)
            {
                response.Success=false;
                response.Message = ex.Message;
            }
            return response;

        }




        public async Task<bool> UserExists(string username)
        {
            if (await db.Users.AnyAsync(user => user.Username.ToLower() == username.ToLower())) return true;
            else return false;
        }





        void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA3_512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        string CreateToken(User_Model user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username)

            };

            var settingsKey = Environment.GetEnvironmentVariable("Token");
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(settingsKey!));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(10),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }



    }
}
