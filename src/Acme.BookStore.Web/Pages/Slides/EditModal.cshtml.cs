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
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditSlideViewModel Slide { get; set; }

        private readonly ISlideAppService _slideAppService;
        private readonly IWebHostEnvironment _ihostingEnvironment;
        public EditModalModel(ISlideAppService slideAppService, IWebHostEnvironment hostingEnvironment)
        {
            _slideAppService = slideAppService;
            _ihostingEnvironment = hostingEnvironment;
        }

        public async Task OnGetAsync(Guid id)
        {
            var slideDto = await _slideAppService.GetAsync(id);
            Slide = ObjectMapper.Map<SlideDto, EditSlideViewModel>(slideDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditSlideViewModel, CreateUpdateSlideDto>(Slide);
            var fileName = ImageUpload(Slide.File, _ihostingEnvironment);
            if (fileName != " ")
            {
                dto.Name = fileName;
            }
                await _slideAppService.UpdateAsync(
                Slide.Id,
                dto);

            return NoContent();
        }

        public class EditSlideViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [StringLength(SlideConsts.MaxNameLength)]
            public string Name { get; set; }

            [HiddenInput]
            public string Image { get; set; }

            [Required]
            [Display(Name = "File")]
            public IFormFile File { get; set; }
            public string Title { get; set; }
            public string Detail { get; set; }
            public float Sale { get; set; }
        }
    }
}
