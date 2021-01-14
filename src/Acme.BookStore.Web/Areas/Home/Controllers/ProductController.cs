using System;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class ProductController : Controller
    {
        private readonly EfCoreAuthorRepository _authorRepository;
        private readonly EfCoreBookRepository _bookRepository;
        private readonly BookAppService _bookAppService;
        public ProductController(EfCoreBookRepository bookRepository, EfCoreAuthorRepository authorRepository, BookAppService bookAppService)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAppService = bookAppService;
        }
        private IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDisplay(Guid id, int? page)
        {
            var category = _authorRepository.GetAsync(id);
            ViewBag.nameCategory = category.Result.Name;
            ViewBag.category = id;

            //linage
            var pageSize = 2;
            var pageNumber = page ?? 1;//How many pages

            var filter = new GetBookListDto
            {
                SkipCount = (pageNumber - 1) * pageSize,//Ignore the number
                MaxResultCount = pageSize
            };
            var product = _bookAppService.GetListBookByAuthorId(id,filter);
            if (product.TotalCount == 0)
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            //Paging logic has been manually completed in the application service layer, so the paging results need to be constructed manually.
            ViewBag.Products = new StaticPagedList<BookDto>(product.Items,pageNumber, pageSize, (int)product.TotalCount);
            return View("ProductDisplay");
        }
        public IActionResult Details(Guid id)
        {
            var product = _bookRepository.GetAsync(id);
            ViewBag.featuredPhoto = product.Result.Image;
            var category = _authorRepository.GetAsync(product.Result.AuthorId);
            ViewBag.nameCategory = category.Result.Name;
            return View("Details",product);
        }
    }
}