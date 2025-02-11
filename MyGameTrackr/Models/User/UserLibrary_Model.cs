namespace MyGameTrackr.Models.User
{
    public class UserLibrary_Model
    {
        public int Id { get; set; }
        public User_Model User { get; set; }
        public int User_ModelId { get; set; }
        public List<GameReview_Model> GamesReviews { get; set; } = new List<GameReview_Model>();
    }
}
