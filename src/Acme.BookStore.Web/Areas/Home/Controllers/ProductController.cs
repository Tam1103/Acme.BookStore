using System;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using X.PagedList;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class ProductController : AbpController
    {
        private readonly AuthorAppService _authorAppService;
        private readonly BookAppService _bookAppService;
        public ProductController(AuthorAppService authorAppService, BookAppService bookAppService)
        {
            _authorAppService = authorAppService;
            _bookAppService = bookAppService;
        }
        private IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDisplay(Guid id, int? page)
        {
            var category = _authorAppService.GetAsync(id);
            ViewBag.nameCategory = category.Result.Name;
            ViewBag.category = id;

            //linage
            Paging.PageNumber = page ?? 1;
            Paging.Filter();

            var product = _bookAppService.GetListBookByAuthorId(id, Paging.filter);
            if (product.TotalCount == 0)
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            //Paging logic has been manually completed in the application service layer, so the paging results need to be constructed manually.
            ViewBag.products = new StaticPagedList<BookDto>(product.Items,Paging.PageNumber, Paging.maxPageSize, (int)product.TotalCount);
            return View("ProductDisplay");
        }
        public IActionResult Details(Guid id)
        {
            var product = _bookAppService.GetAsync(id);
            ViewBag.featuredPhoto = product.Result.Image;
            var category = _authorAppService.GetAsync(product.Result.AuthorId);
            ViewBag.nameCategory = category.Result.Name;
            return View("Details",product);
        }
    }
}