using Acme.BookStore.Authors;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Areas.Home.Components
{
    [ViewComponent(Name = "Search")]
    public class SearchViewComponent : ViewComponent
    {
        private BookStoreDbContext db;
        public SearchViewComponent(BookStoreDbContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Author> categories = db.Authors.ToList();
            return View("Index",categories);
        } 
    }
}
