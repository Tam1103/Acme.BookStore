using Acme.BookStore.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Areas.Home.Components
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent: ViewComponent
    {
        private readonly EfCoreAuthorRepository _authorRepository;
        public CategoryViewComponent(EfCoreAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _authorRepository.GetListAsync();
            return View("Index",categories);
        }
    }
}
