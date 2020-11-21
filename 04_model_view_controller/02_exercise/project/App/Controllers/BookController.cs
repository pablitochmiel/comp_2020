using System.Linq;
using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utils;

namespace App.Controllers
{
    [Authorize]
    public class BookController:Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public BookController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            // var book = new Book { Title = "tytul",Description = "opis"};
            // _context.Books?.Add(book);
            // _context.SaveChanges();
            // var list = _context.Books?.ToList();
            // if (list != null)
            // {
            //     foreach (var item in list.Where(item => string.IsNullOrEmpty(item.Title)))
            //     {
            //         _context.Books?.Remove(item);
            //     }
            //
            //     _context.SaveChanges();
            // }

            _logger.LogInformation("BookController Index()");
            return View(_context.Books?.ToList());
        }
        
        public IActionResult Create() // - displays a form for creating a new book
        {
            _logger.LogInformation("BookController Create()");
            return View();
            }

        [HttpPost]        
        public IActionResult Store() // - saves the book in the database - redirection to Index after adding or to Store after error
        {
            var title = Request.Form["Title"];
            var description = Request.Form["Description"];
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                return RedirectToAction("Create");
            }
            _context.Books?.Add(new Book{Title = title,Description = description});
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}