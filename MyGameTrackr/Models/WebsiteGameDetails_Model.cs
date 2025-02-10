namespace MyGameTrackr.Models
{
    public class WebsiteGameDetails_Model
    {
        public int Id { get; set; }
        public GameReview_Model Game {  get; set; }
        public int GameId {  get; set; }
        public int APIGameId {  get; set; }
        public string gameName { get; set; }
        public int OverallScore {  get; set; }
        public List<GameReview_Model> Reviews { get; set; } = new List<GameReview_Model>();
    }
}
