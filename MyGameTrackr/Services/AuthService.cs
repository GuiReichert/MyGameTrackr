using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
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
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == Username.ToLower());
                if(user == null  || !VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Username or Password incorrect");
                }
                response.Data = user.Id.ToString();
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
            if (await db.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower())) return true;
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


    }
}
