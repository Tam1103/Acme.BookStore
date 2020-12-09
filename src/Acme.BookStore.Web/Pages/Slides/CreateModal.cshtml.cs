using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Slides;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Slides
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateSlideViewModel Slide { get; set; }
        private readonly ISlideAppService _slideAppService;
        public CreateModalModel(ISlideAppService slideAppService)
        {
            _slideAppService = slideAppService;
        }

        public void OnGet()
        {
            Slide = new CreateSlideViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateSlideViewModel, CreateUpdateSlideDto>(Slide);
            await _slideAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateSlideViewModel
        {

            [Required]
            [StringLength(128)]
            public string Name { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Detail { get; set; }
            public float Sale { get; set; }

        }
    }
}
