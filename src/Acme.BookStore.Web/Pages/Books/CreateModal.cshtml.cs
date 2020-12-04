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
using Acme.BookStore.Blob;
using System.IO;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateBookViewModel Book { get; set; }

        public List<SelectListItem> Authors { get; set; }

        private readonly IBookAppService _bookAppService;
        private readonly IFileAppService _fileAppService;
        public CreateModalModel(IBookAppService bookAppService, IFileAppService fileAppService)
        {
            _bookAppService = bookAppService;
            _fileAppService = fileAppService;
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
            string nameImage = "Img" + Guid.NewGuid() + ".png";
            using (var memoryStream = new MemoryStream())
            {
                await Book.File.CopyToAsync(memoryStream);

                await _fileAppService.SaveBlobAsync(
                    new SaveBlobInputDto
                    {
                        Name = nameImage,
                        Content = memoryStream.ToArray()
                    }
                );
            }
            dto.Image = nameImage;

            await _bookAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateBookViewModel
        {
            [SelectItems(nameof(Authors))]
            [DisplayName("Author")]
            public Guid AuthorId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; }

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
