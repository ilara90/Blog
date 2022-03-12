using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ArticlesTags> ArticlesTags { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Article>()
                    .HasMany(c => c.Tags)
                    .WithMany(s => s.Articles)
                    .UsingEntity<ArticlesTags>(
                j => j
                        .HasOne(pt => pt.Tag)
                        .WithMany(t => t.ArticlesTags)
                        .HasForeignKey(pt => pt.TagId),
                j => j
                        .HasOne(pt => pt.Article)
                        .WithMany(p => p.ArticlesTags)
                        .HasForeignKey(pt => pt.ArticleId));
        }
    }
}