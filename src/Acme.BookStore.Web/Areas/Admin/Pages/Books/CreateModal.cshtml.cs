using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Acme.BookStore.Web.Areas.Admin.Pages.Books
{
    public class CreateModalModel : BookStorePageModel
    {
        private IWebHostEnvironment ihostingEnvironment;
        [BindProperty]
        public CreateBookViewModel Book { get; set; }

        public List<SelectListItem> Authors { get; set; }
        public bool Uploaded { get; set; } = false;
        private readonly IBookAppService _bookAppService;
        public CreateModalModel(IBookAppService bookAppService, IWebHostEnvironment _ihostingEnvironment)
        {
            _bookAppService = bookAppService;
            ihostingEnvironment = _ihostingEnvironment;
        }

        public async Task OnGetAsync()
        {
            Book = new CreateBookViewModel();

            var authorLookup = await _bookAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateBookViewModel, CreateUpdateBookDto>(Book);

            var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + Book.File.FileName;
            var path = Path.Combine(this.ihostingEnvironment.WebRootPath, "books", fileName);
            var stream = new FileStream(path, FileMode.Create);
            await Book.File.CopyToAsync(stream);
            dto.Image = fileName;

            await _bookAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateBookViewModel
        {
            [SelectItems(nameof(Authors))]
            [DisplayName("Author")]
            public Guid AuthorId { get; set; }

            [Required]
            [StringLength(BookConsts.MaxNameLength)]
            public string Name { get; set; }
            
            [Required]
            [Display(Name = "Filename")]
            public string Image { get; set; }

            [Required]
            [Display(Name = "File")]
            public IFormFile File { get; set; }
           
            [Required]
            public BookType Type { get; set; } = BookType.Undefined;

            [Required]
            [DataType(DataType.Date)]
            public DateTime PublishDate { get; set; } = DateTime.Now;
            
            [Required]
            public float Price { get; set; }
        }
    }
}
