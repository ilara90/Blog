using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Not specified title")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 50 characters")]
        public string? Title { get; set; }
        public byte? IsDeleted { get; set; }
        public List<Article> Articles { get; set; } = new();
        public List<ArticlesTags> ArticlesTags { get; set; } = new();
    }
}
