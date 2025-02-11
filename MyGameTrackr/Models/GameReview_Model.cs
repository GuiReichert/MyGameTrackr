using MyGameTrackr.Models.User;

namespace MyGameTrackr.Models
{
    public class GameReview_Model
    {
        public int Id {  get; set; }
        public Game_Model Game_Model { get; set; }
        public int Game_ModelId { get; set; }
        public UserLibrary_Model UserLibrary { get; set; }
        public int Score {  get; set; }
        public string Comment {  get; set; } = string.Empty;
        public bool isAnonymousReview { get; set; }
        public GameState CurrentState { get; set; } = GameState.Wishlist;
        public DateTime LastStateUpdated { get; set; }

    }
}
