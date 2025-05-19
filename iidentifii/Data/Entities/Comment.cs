using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iidentifii.Data.Entities
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int Likes { get; set; }
        public int CommentUserId { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        protected Comment() { } // For EF Core

        public Comment(int commentId, string? content, int userId, int postId, int likes)
        {
            CommentId = commentId;
            Content = content;
            CommentUserId = userId;;
            PostId = postId;
            Likes = likes;
        }
    }
}
