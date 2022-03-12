namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte? IsDeleted { get; set; }
    }
}
