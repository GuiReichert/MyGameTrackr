namespace MyGameTrackr.Services
{
    public interface IWebsiteServices
    {
        public void AddGameToWebsiteDb();
        public void ProcessOverallScore();
        public void AddReview();
        public void DeleteReview();
        public void UpdateReview();

    }
}
