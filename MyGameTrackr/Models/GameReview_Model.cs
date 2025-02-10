namespace MyGameTrackr.Models
{
    public class GameReview_Model
    {
        int Id {  get; set; }
        public WebsiteGameDetails_Model Game { get; set; }
        public int GameId { get; set; }
        public string Username {  get; set; } = string.Empty;
        public string? Score {  get; set; }
        public string? Comment {  get; set; }
        public bool isAnonymous { get; set; }

    }
}
