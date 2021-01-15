using System;
using Abp.Application.Services.Dto;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    public class ProductController : Controller
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
            var pageSize = 2;
            var pageNumber = page ?? 1;//How many pages

            var filter = new GetBookListDto
            {
                SkipCount = (pageNumber - 1) * pageSize,//Ignore the number
                MaxResultCount = pageSize
            };
            var category = _authorAppService.GetAsync(id);
            ViewBag.nameCategory = category.Result.Name;
            var product = _bookAppService.GetListBookByAuthorId(id,filter);
            if (product.Result.TotalCount == 0)
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            return View("ProductDisplay",product);
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