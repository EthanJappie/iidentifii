using iidentifii.Models.Comments;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace iidentifii.Models.Posts
{
    public class PostSummaryViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int Likes { get; set; }
        public int PostUserId { get; set; }
        public ICollection<CommentSummaryViewModel> Comments { get; set; }

        public PostSummaryViewModel(int postId, string title, string content, int likes, int postUserId, ICollection<CommentSummaryViewModel> comments)
        {
            PostId = postId;
            Title = title;
            Content = content;
            Likes = likes;
            PostUserId = postUserId;
            Comments = comments;
        }
    }
}
