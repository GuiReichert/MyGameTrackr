using MyGameTrackr.Models;

namespace MyGameTrackr.DTO_s
{
    public class GetLibraryGameReviewDTO
    {
        public string GameName { get; set; } = string.Empty;
        public GameState CurrentState { get; set; }
        public string LastStateUpdated { get; set; } = string.Empty;
        public int Score { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
