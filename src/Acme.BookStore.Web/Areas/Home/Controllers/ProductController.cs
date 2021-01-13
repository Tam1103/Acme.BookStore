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
        private readonly EfCoreAuthorRepository _authorRepository;
        private readonly EfCoreBookRepository _bookRepository;
        public ProductController(EfCoreBookRepository bookRepository, EfCoreAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        private IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDisplay(Guid id, int? page)
        {
            var pageSize = 2;
            var pageNumber = page ?? 1;//How many pages

            var filter = new PagedAndSortedResultRequestDto
            {
                SkipCount = (pageNumber - 1) * pageSize,//Ignore the number
                MaxResultCount = pageSize
            };
            var category = _authorRepository.GetAsync(id);
            ViewBag.nameCategory = category.Result.Name;
            var product = _bookRepository.GetListBookByAuthorId(id,filter);
            if (product.Result.Count == 0)
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            return View("ProductDisplay",product);
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