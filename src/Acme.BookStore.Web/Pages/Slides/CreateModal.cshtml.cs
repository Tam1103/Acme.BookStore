using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Acme.BookStore.Slides;
using Acme.BookStore.Web.Pages.Slides;
using Acme.BookStore.Web.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Slides
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateSlideViewModel Slide { get; set; }
        private readonly ISlideAppService _slideAppService;
        private readonly IWebHostEnvironment _ihostingEnvironment;
        public CreateModalModel(ISlideAppService slideAppService, IWebHostEnvironment _ihot)
        {
            _slideAppService = slideAppService;
            _ihostingEnvironment = _ihot;
        }

        public void OnGet()
        {
            Slide = new CreateSlideViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var dto = ObjectMapper.Map<CreateSlideViewModel, CreateUpdateSlideDto>(Slide);

            var fileName = ImageUpload(Slide.File, _ihostingEnvironment);
            dto.Name = fileName;
            await _slideAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateSlideViewModel
        {

            [Required]
            [StringLength(SlideConsts.MaxNameLength)]
            public string Name { get; set; }

            [Required]
            [Display(Name = "File")]
            public IFormFile File { get; set; }

            [Required]
            public string Title { get; set; }
            [Required]
            public string Detail { get; set; }
            public float Sale { get; set; }

        }
    }
}
