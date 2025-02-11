using MyGameTrackr.Models;

namespace MyGameTrackr.DTO_s.PublicReviewsDTO_s
{
    public class GetPublicGameReviewsDTO
    {
        public string GameName { get; set; } = string.Empty;
        public List<SingularGameReviewDTO> GameReviews {  get; set; } = new List<SingularGameReviewDTO>();
    }
}
