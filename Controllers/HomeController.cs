using Blog.Data;
using Blog.Models;
using Blog.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> Index(int? category, DateTime? dateFrom, DateTime? dateTo, List<int>? tagIds, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Administration");
            }

            int pageSize = 2;   //количество элементов на странице

            IQueryable<Article> articles = db.Articles
                .Include(x => x.Category)
                .Include(x => x.Tags);

            if (category != null && category != 0)
            {
                articles = articles.Where(p => p.CategoryId == category);
            }

            if (dateFrom != null)
            {
                articles = articles.Where(p => p.DateTime > dateFrom);
            }

            if (dateTo != null)
            {
                articles = articles.Where(p => p.DateTime < dateTo);
            }

            if (tagIds != null)
            {
                articles = articles.Where(p => p.Tags.Where(x => tagIds.Contains(x.Id)).Count() == tagIds.Count);
            }

            var count = await articles.CountAsync();
            var items = await articles.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var categories = new SelectList(db.Categories
                .Where(y => y.IsDeleted == 0)
                .Select(x => new { x.Id, x.Title }), "Id", "Title");

            var tags = new SelectList(db.Tags
                .Where(y => y.IsDeleted == 0)
                .Select(x => new { x.Id, x.Title }), "Id", "Title");

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterViewModel filterViewModel = new FilterViewModel(category, dateFrom, dateTo, tagIds);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items,
                FilterViewModel = filterViewModel,
                Categories = categories,
                Tags = tags
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles
                    .Include(x => x.Category)
                    .Include(t => t.Tags)
                    .FirstOrDefaultAsync(p => p.Id == id);

                return View(article);
            }

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}