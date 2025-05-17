using Microsoft.AspNetCore.Identity;

namespace iidentifii.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int PostUserId { get; set; }
        public int Likes { get; set; }
        public IdentityUser? User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        protected Post() { } // For EF Core

        public Post(string? title, string? content, int userId, IdentityUser? user)
        {
            Title = title;
            Content = content;
            PostUserId = userId;
            User = user;
            Likes = 0;
            Comments = new List<Comment>();
        }

    }
}
