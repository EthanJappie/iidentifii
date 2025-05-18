using Microsoft.AspNetCore.Identity;

namespace iidentifii.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int Likes { get; set; }
        public int CommentUserId { get; set; }
        public IdentityUser User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        protected Comment() { } // For EF Core

        public Comment(int commentId,string? content, int userId, int postId, int likes)
        {
            CommentId = commentId;
            Content = content;
            CommentUserId = userId;;
            Likes = 0;
            PostId = postId;
            Likes = likes;
        }
    }
}
