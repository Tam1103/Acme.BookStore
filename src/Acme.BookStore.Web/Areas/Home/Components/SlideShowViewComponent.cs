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
        private readonly EfCoreSlideRepository _slideRepository;
        public SlideShowViewComponent(EfCoreSlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slideshow = await _slideRepository.GetListAsync();
            return View("Index", slideshow);
        }
    }
}