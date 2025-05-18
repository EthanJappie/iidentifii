namespace iidentifii.Models.Posts
{
    public class PostOverviewModel
    {
        public List<PostSummaryViewModel> Posts { get; set; } = new List<PostSummaryViewModel>();

        public PostOverviewModel()
        {
        }
        public PostOverviewModel(List<PostSummaryViewModel> posts)
        {
            Posts = posts;
        }
    }
}
