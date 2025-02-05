namespace MyGameTrackr.Models.User
{
    public class UserGames_Model
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int GameId {  get; set; }
        public string GameName { get; set; } = string.Empty;
        public GameState? CurrentState;
        public int? Score { get; set; }
        public DateTime? LastStateUpdate { get; set; }
        public string Comment { get; set; } = string.Empty;
        
    }
}
