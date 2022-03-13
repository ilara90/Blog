using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Not specified title")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 50 characters")]
        public string? Title { get; set; }
        [StringLength(250, MinimumLength = 0, ErrorMessage = "The length of the string must be up to 250 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Enter the text of the article")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "Select a category")]
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
