using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Slides;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Areas.Home.Components
{
    [ViewComponent(Name = "SlideShow")]
    public class SlideShowViewComponent : ViewComponent
    {
        private BookStoreDbContext db;
        public SlideShowViewComponent(BookStoreDbContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Slide> slideshow = db.Slides.ToList();
            return View("Index", slideshow);
        }
    }
}
