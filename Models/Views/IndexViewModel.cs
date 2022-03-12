using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Models.Views
{
    public class IndexViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Tags { get; set; }
        public List<int> TagIds { get; set; }
    }
}
