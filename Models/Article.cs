using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Not specified title")]
        public string? Title { get; set; }
        [StringLength(250, MinimumLength = 0, ErrorMessage = "The length of the string must be up to 250 characters")]
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
