using BookShop.Data;
using BookShop.ViewModel;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(BookDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            dbContext = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var books = await dbContext.Books.ToListAsync();
            return View(books);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniFileName = UploadedFile(model);
                Book employee = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Price = model.Price,
                    PublicDate = model.PublicDate,
                    CategoryID = model.CategoryID,
                    Picture = uniFileName
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        private string UploadedFile(BookViewModel model)
        {
            string uniFileName = null;
            if (model.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Picture.CopyTo(fileStream);
                }
            }
            return uniFileName;
        }
    }
}
