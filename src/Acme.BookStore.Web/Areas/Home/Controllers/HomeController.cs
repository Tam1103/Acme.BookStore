using Acme.BookStore.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookStoreDbContext _context;
        public HomeController(BookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var product = _context.Books.OrderByDescending(p => p.Id).Take(4).ToList();
            return View("Index", product);
        }

        [HttpGet]
        [Route("error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
