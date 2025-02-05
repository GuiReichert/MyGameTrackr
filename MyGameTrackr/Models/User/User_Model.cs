namespace MyGameTrackr.Models.User
{
    public class User_Model
    {
        public int Id { get; set; }
        public string Username { get; set; }   
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<UserGames_Model> UserGames { get; set; } = new List<UserGames_Model>();
    }
}
