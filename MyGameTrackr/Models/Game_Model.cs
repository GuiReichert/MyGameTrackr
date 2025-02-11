using MyGameTrackr.Models.User;

namespace MyGameTrackr.Models
{
    public class Game_Model
    {
        public int Id { get; set; }
        public int APIGameId { get; set; }
        public string GameName { get; set; } = string.Empty;
        public float OverallScore {  get; set; }
        public List<GameReview_Model> Reviews { get; set; } = new List<GameReview_Model>();
    }
}
