using Microsoft.AspNetCore.Identity;

namespace MyGameTrackr.Models.User
{
    public class User_Model
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public UserLibrary_Model UserLibrary { get; set; } = new UserLibrary_Model();
    }
}
