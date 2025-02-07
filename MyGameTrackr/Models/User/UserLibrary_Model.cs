namespace MyGameTrackr.Models.User
{
    public class UserLibrary_Model
    {
        public int Id { get; set; }
        public User_Model User { get; set; }
        public int User_ModelId { get; set; }
        public List<LibraryGames_Model>? Games { get; set; }
    }
}
