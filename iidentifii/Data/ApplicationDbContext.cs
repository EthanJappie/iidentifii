using iidentifii.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iidentifii.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configure the primary key for the Post entity
            builder.Entity<Post>()
                .HasKey(p => p.PostId);
            // Configure the primary key for the Comment entity
            builder.Entity<Comment>()
                .HasKey(c => c.CommentId);
            // Configure the relationship between Post and Comment
            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Entity<Post>().HasData(
                new Post(1,"First Post", "This is the content of the first post.", 1, new List<Comment>()),
                new Post(2,"Second Post", "This is the content of the second post.", 1, new List<Comment>())
            );
        }
    }
}
