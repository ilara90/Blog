using AutoMapper;
using Blog.Data;
using Blog.Models;
using Blog.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Blog.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly ILogger<AdministrationController> _logger;
        private ApplicationDbContext db;
        private IMapper _mapper;

        public AdministrationController(ILogger<AdministrationController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int? category, DateTime? dateFrom, DateTime? dateTo, List<int> tagIds, int page = 1)
        {
            int pageSize = 2;

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
        public IActionResult Create()
        {
            var categories = new SelectList(db.Categories
                .Where(y => y.IsDeleted == 0)
                .Select(x => new { x.Id, x.Title }), "Id", "Title");

            var tags = new SelectList(db.Tags
                .Where(y => y.IsDeleted == 0)
                .Select(x => new { x.Id, x.Title }), "Id", "Title");

            CreateViewModel viewModel = new CreateViewModel
            {
                Categories = categories,
                Tags = tags
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImageFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ImageFile.Length);
                }
                article.Image = imageData;
            }

            article.DateTime = DateTime.Now;
            db.Articles.Add(article);
            await db.SaveChangesAsync();
            var articlesTagsNew = article.TagIds.Select(x => new ArticlesTags { ArticleId = article.Id, TagId = x });
            await db.ArticlesTags.AddRangeAsync(articlesTagsNew);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Article article = await db.Articles
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (article != null)
            {
                var editView = _mapper.Map<EditViewModel>(article);

                editView.Categories = new SelectList(db.Categories
                    .Where(x => x.IsDeleted == 0)
                    .Select(z => new { z.Id, z.Title }), "Id", "Title");

                editView.Tags = new SelectList(db.Tags
                .Where(y => y.IsDeleted == 0)
                .Select(x => new { x.Id, x.Title }), "Id", "Title");

                return View(editView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article article, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImageFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ImageFile.Length);
                }
                article.Image = imageData;
            }
            var articlesTagsToDelete = db.ArticlesTags.Where(x => x.ArticleId == article.Id);
            db.ArticlesTags.RemoveRange(articlesTagsToDelete);
            var articlesTagsNew = article.TagIds.Select(x => new ArticlesTags { ArticleId = article.Id, TagId = x });
            await db.ArticlesTags.AddRangeAsync(articlesTagsNew);
            db.Articles.Update(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                    return View(article);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                {
                    var articlesTagsToDelete = db.ArticlesTags.Where(x => x.ArticleId == article.Id);
                    db.ArticlesTags.RemoveRange(articlesTagsToDelete);
                    db.Articles.Remove(article);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public IActionResult ActionCategories()
        {
            IQueryable<Category> categories = db.Categories;

            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            category.IsDeleted = 0;
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("ActionCategories");
        }

        [HttpGet]
        [ActionName("DeleteCategory")]
        public async Task<IActionResult> ConfirmDeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                {
                    category.IsDeleted = 1;
                    db.Categories.Update(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ActionCategories");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (category != null)
            {
                category.IsDeleted = 0;
                db.Categories.Update(category);
                await db.SaveChangesAsync();
                return RedirectToAction("ActionCategories");
            }

            return NotFound();
        }

        public IActionResult ActionTags()
        {
            IQueryable<Tag> tags = db.Tags;

            return View(tags);
        }

        [HttpGet]
        [ActionName("DeleteTag")]
        public async Task<IActionResult> ConfirmDeleteTag(int? id)
        {
            if (id != null)
            {
                Tag tag = await db.Tags.FirstOrDefaultAsync(p => p.Id == id);
                if (tag != null)
                    return View(tag);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag(int? id)
        {
            if (id != null)
            {
                Tag tag = await db.Tags.FirstOrDefaultAsync(p => p.Id == id);
                if (tag != null)
                {
                    tag.IsDeleted = 1;
                    db.Tags.Update(tag);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ActionTags");
                }
            }
            return NotFound();
        }

        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(Tag tag)
        {
            tag.IsDeleted = 0;
            db.Tags.Add(tag);
            await db.SaveChangesAsync();
            return RedirectToAction("ActionTags");
        }
    }
}
