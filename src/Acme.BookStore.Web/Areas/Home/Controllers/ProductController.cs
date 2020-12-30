using System;
using System.Linq;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Acme.BookStore.Web.Areas.Home.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly BookStoreDbContext db;
        public ProductController(BookStoreDbContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("productdisplay/{id}")]
        public IActionResult ProductDisplay(Guid id, int? page)
        {
            var pageNumber = page ?? 1;
            var category = db.Authors.Find(id);
            ViewBag.category = category;
            ViewBag.nameCategory = category.Name;
            var product = db.Books.Where(b => b.AuthorId == id);
            if (!product.Any())
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            return View("ProductDisplay",product.ToPagedList(pageNumber, 4));
        }
        
        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(Guid id)
        {
            var product = db.Books.Find(id);
            ViewBag.featuredPhoto = product.Image;

            var category = db.Authors.Find(product.AuthorId);
            ViewBag.nameCategory = category.Name;
            ViewBag.releatedProducts = db.Books.Where(p => p.AuthorId == product.AuthorId && p.Id != product.Id).ToList();
           
            return View("Details", product);
        }
    }
}