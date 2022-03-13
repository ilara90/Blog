using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Models.Views
{    
    public class CreateViewModel
    {
        public SelectList Categories { get; set; }
        public SelectList Tags { get; set; }
        public List<int> TagIds { get; set; }
        public Article articleModel { get; set; }
    }
}
