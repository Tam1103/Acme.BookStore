using Acme.BookStore.Books;
using Acme.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using X.PagedList;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class HomeController : AbpController
    {
        private readonly BookAppService _bookAppService;
        public HomeController(BookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        public IActionResult Public(int? page)
        {
            Paging.PageNumber = page ?? 1;
            Paging.Filter();

            var product = _bookAppService.GetListValue(Paging.filter);
            if (product.TotalCount == 0)
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            //Paging logic has been manually completed in the application service layer, so the paging results need to be constructed manually.
            var products = new StaticPagedList<BookDto>(product.Items, Paging.PageNumber, Paging.maxPageSize, (int)product.TotalCount);

            return View("public", products);
        }
        
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
