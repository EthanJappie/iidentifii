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
            
            builder.Entity<Post>().Property(p => p.PostId).ValueGeneratedOnAdd().HasDefaultValue(1);
            // Configure the primary key for the Comment entity
            builder.Entity<Comment>()
                .HasKey(c => c.CommentId);
            builder.Entity<Comment>().Property(c => c.CommentId).ValueGeneratedOnAdd().HasDefaultValue(1);
            // Configure the relationship between Post and Comment
            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Entity<Post>().HasData(
                new Post("First Post", "This is the content of the first post.", 1) { PostId = 1, PostUserId = 1},
                new Post("Second Post", "This is the content of the second post.", 1) { PostId = 2 , PostUserId = 1}
            );

            builder.Entity<Comment>().HasData(
                new Comment( "This is a comment on the first post.", 1, 1, 10) { CommentId = 3},
                new Comment("This is a comment on the second post.", 1, 2, 2) { CommentId = 4 }
            );
        }
    }
}
