﻿namespace MyGameTrackr.Models.User
{
    public class LibraryGames_Model
    {
        public int Id { get; set; }
        public UserLibrary_Model UserLibrary {  get; set; }
        public int APIGameId {  get; set; }
        public string GameName { get; set; } = string.Empty;

        public GameState CurrentState { get; set; } = GameState.Wishlist;
        public int? Score { get; set; }
        public DateTime? LastStateUpdate { get; set; }
        public string Comment { get; set; } = string.Empty;
        
    }
}
