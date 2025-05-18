using iidentifii.Data.Entities;
using iidentifii.Models.Comments;
using iidentifii.Models.Posts;

namespace iidentifii.EntityModelMappers
{
    public static class EntityMapping
    {
        public static PostOverviewModel MapPostsToViewModels(IEnumerable<Post> posts)
        {
            var postViewModels = new PostOverviewModel();

            var postDetails = posts.Select(post => new PostSummaryViewModel
            (
                post.PostId, // Pass the required 'postId' parameter
                post.Title ?? string.Empty, // Handle potential null values
                post.Content ?? string.Empty, // Handle potential null values
                post.Likes,
                post.PostUserId,
                [.. post.Comments.Select(comment => new CommentSummaryViewModel
                (
                    comment.CommentId,
                    comment.Content ?? string.Empty, // Handle potential null values
                    comment.Likes,
                    comment.PostId,
                    comment.CommentUserId
                ))]
            ));

            postViewModels.Posts.AddRange(postDetails);

            return postViewModels;
        }
    }
}
