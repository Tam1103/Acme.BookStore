using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Books
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditBookViewModel Book { get; set; }

        public List<SelectListItem> Authors { get; set; }

        private readonly IBookAppService _bookAppService;
        private IWebHostEnvironment ihostingEnvironment;
        public EditModalModel(IBookAppService bookAppService, IWebHostEnvironment _ihostingEnvironment)
        {
            _bookAppService = bookAppService;
            ihostingEnvironment = _ihostingEnvironment;
        }

        public async Task OnGetAsync(Guid id)
        {
            var bookDto = await _bookAppService.GetAsync(id);
            Book = ObjectMapper.Map<BookDto, EditBookViewModel>(bookDto);

            var authorLookup = await _bookAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditBookViewModel, CreateUpdateBookDto>(Book);

            var fileName = ImageUpload(Book.File, ihostingEnvironment);
            if (fileName != " ")
            {
                dto.Image = fileName;
            }
            await _bookAppService.UpdateAsync(
              Book.Id,
              dto);

            return NoContent();
        }

        public class EditBookViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Authors))]
            [DisplayName("Author")]
            public Guid AuthorId { get; set; }

            [StringLength(BookConsts.MaxNameLength)]
            public string Name { get; set; }

            [HiddenInput]
            public string Image { get; set; }

            public IFormFile File { get; set; }

            public BookType Type { get; set; }

            [DataType(DataType.Date)]
            public DateTime PublishDate { get; set; } = DateTime.Now;

            public float Price { get; set; }
        }
    }
}
