using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Acme.BookStore.Slides;
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
        private readonly IHostingEnvironment _ihostingEnvironment;
        public CreateModalModel(ISlideAppService slideAppService, IHostingEnvironment _ihot)
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

            var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + Slide.File.FileName;
            var path = Path.Combine(this._ihostingEnvironment.WebRootPath, "slide", fileName);
            var stream = new FileStream(path, FileMode.Create);
            await Slide.File.CopyToAsync(stream);
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
