using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime DateTime { get; set; }
        public byte[]? Image { get; set; }
        public List<Tag> Tags { get; set; } = new();
        [NotMapped]
        public List<int> TagIds { get; set; }
        public List<ArticlesTags> ArticlesTags { get; set; } = new();
    }
}
