using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Models.Views
{    
    public class CreateViewModel : Article
    {
        public SelectList Categories { get; set; }
        public SelectList Tags { get; set; }
    }
}
