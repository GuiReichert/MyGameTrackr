using MyGameTrackr.Models;

namespace MyGameTrackr.DTO_s
{
    public class GetLibraryGameDetailDTO
    {
        public int APIGameId { get; set; }
        public string GameName { get; set; } = string.Empty;
        public GameState CurrentState { get; set; } = GameState.Wishlist;
        DateTime? LastStateUpdated { get; set; }
        public int? Score { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
