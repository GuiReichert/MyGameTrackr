using MyGameTrackr.Models;

namespace MyGameTrackr.DTO_s.PublicReviewsDTO_s
{
    public class SingularGameReviewDTO
    {
        public string Username {  get; set; } = string.Empty;
        public int Score { get; set; }
        public GameState CurrentState { get; set; }
        public string LastUpdate { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
    }
}
