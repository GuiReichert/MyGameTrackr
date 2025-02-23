﻿using MyGameTrackr.Models;

namespace MyGameTrackr.DTO_s.LibraryDTO_s
{
    public class AddLibraryGameReviewDTO
    {
        public int APIGameId { get; set; }
        public string CurrentState { get; set; } = "Wishlist";
        public int Score { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool isAnonymousReview {  get; set; }
    }
}
