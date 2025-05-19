using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iidentifii.Data.Entities
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int PostUserId { get; set; }
        public int Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        protected Post() { } // For EF Core

        public Post(int postId,string? title, string? content, int userId)
        {
            PostId = postId;
            Title = title;
            Content = content;
            PostUserId = userId;
            Likes = 0;
        }

    }
}
