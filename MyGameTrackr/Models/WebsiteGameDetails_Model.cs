namespace MyGameTrackr.Models
{
    public class WebsiteGameDetails_Model
    {
        public int Id { get; set; }
        public int APIGameId {  get; set; }
        public string gameName { get; set; } = string.Empty;
        public float OverallScore {  get; set; }
        public List<GameReview_Model> Reviews { get; set; } = new List<GameReview_Model>();
    }
}
