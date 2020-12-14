using Acme.BookStore.Slides;
using System.Collections.Generic;

namespace Acme.BookStore.Web.Pages.Slides
{
    public class IndexModel
    {
        public IReadOnlyList<SlideDto> Slides { get; }
        public IndexModel(IReadOnlyList<SlideDto> Slide)
        {
            Slides = Slide;
        }
        public void OnGet()
        {
        }
    }
}
