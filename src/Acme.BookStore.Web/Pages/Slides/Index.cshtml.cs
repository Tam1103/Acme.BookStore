using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Slides;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Acme.BookStore.Web.Pages.Slides
{
    public class IndexModel : PageModel
    {
        private readonly BookStoreDbContext _db;
        public List<Slide> Slides;
        public SlideAppService SlideApp;
        public IndexModel(BookStoreDbContext db)
        {
             Slides = new List<Slide>();
            _db = db;
        }
        public void OnGet()
        {
            foreach (var item in _db.Slides)
            {
                Slides.Add(item);
            }
        }
    }
}
