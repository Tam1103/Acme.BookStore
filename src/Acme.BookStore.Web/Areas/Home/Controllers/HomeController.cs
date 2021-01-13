using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfCoreBookRepository _bookRepository;
        public HomeController(EfCoreBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var product = _bookRepository.OrderByDescending(p => p.Id).Take(4);
            return View("Index", product);
        }
        
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
