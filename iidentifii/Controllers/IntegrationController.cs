using iidentifii.Data;
using iidentifii.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iidentifii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IntegrationController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public IntegrationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpGet("posts")]
        public async Task<IActionResult> GetPostsAsync()
        {
            var posts = await _dbContext.Posts.ToListAsync();

            if (posts != null && posts.Count > 0)
            {
                return new JsonResult(posts);
            }

            return NotFound();
        }

        [HttpPost("addPost")]
        public async Task<IActionResult> AddPostAsync([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post cannot be null.");
            }
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostsAsync), new { id = post.PostId }, post);
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> AddCommentAsync([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("Comment cannot be null.");
            }
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostsAsync), new { id = comment.CommentId }, comment);
        }

        [HttpPost("likeComment/{commentId}")]
        public async Task<IActionResult> LikeCommentAsync(int commentId)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }
            comment.Likes++;
            await _dbContext.SaveChangesAsync();
            return Ok(comment);
        }
    }
}
