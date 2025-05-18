namespace iidentifii.Models.Comments
{
    public class CommentSummaryViewModel
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int Likes { get; set; }
        public int PostId { get; set; }
        public int CommentUserId { get; set; }

        public CommentSummaryViewModel(int commentId, string content, int likes, int postId, int commentUserId)
            {
                CommentId = commentId;
                Content = content;
                Likes = likes;
                PostId = postId;
                CommentUserId = commentUserId;
        }
    }
}
