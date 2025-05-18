using iidentifii.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace iidentifii.Data.Service
{
    public static class DataService
    {
        public static IQueryable<Post> GetPosts(this ApplicationDbContext context)
        {
            return context.Posts.Include(p => p.Comments).AsQueryable();
        }

        public static IQueryable<Post> GetUserPosts(this ApplicationDbContext context, int userId)
        {
            return context.Posts.Include(p => p.Comments).Where(p => p.PostUserId == userId).AsQueryable();
        }

        public async static void AddPost(this ApplicationDbContext context, Post post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async static void LikePost(this ApplicationDbContext context, int postId)
        {
            var post = await context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.Likes++;
                await context.SaveChangesAsync();
            }
        }

        public async static void LikeComment(this ApplicationDbContext context, int commentId)
        {
            var comment = await context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                comment.Likes++;
                await context.SaveChangesAsync();
            }
        }

        public async static void AddComment(this ApplicationDbContext context, Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }
    }
}
