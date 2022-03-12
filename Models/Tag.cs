namespace Blog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte? IsDeleted { get; set; }
        public List<Article> Articles { get; set; } = new();
        public List<ArticlesTags> ArticlesTags { get; set; } = new();
    }
}
