using System.Linq;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Utils;

namespace App.Controllers
{
    public class BookController:Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public BookController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            // var book = new Book { Title = "tytul",Description = "opis"};
            // _context.Books?.Add(book);
            // _context.SaveChanges();
            _logger.LogInformation("BookController Index()");
            return View(_context.Books?.ToList());
        }

        public IActionResult Create() // - displays a form for creating a new book
        {
            _logger.LogInformation("BookController Create()");
            return View();
        }

        public void Store() // - saves the book in the database - redirection to Index after adding or to Store after error
        {
            
        }
    }
}