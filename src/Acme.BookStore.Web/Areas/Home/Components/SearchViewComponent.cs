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
        private readonly EfCoreAuthorRepository _authorRepository;
        public SearchViewComponent(EfCoreAuthorRepository authorRepository)
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
