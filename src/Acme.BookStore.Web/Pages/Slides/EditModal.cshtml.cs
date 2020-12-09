using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Acme.BookStore.Slides;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Slides
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditSlideViewModel Slide { get; set; }

        private readonly ISlideAppService _SlideAppService;
        public EditModalModel(ISlideAppService slideAppService)
        {
            _SlideAppService = slideAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var slideDto = await _SlideAppService.GetAsync(id);
            Slide = ObjectMapper.Map<SlideDto, EditSlideViewModel>(slideDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _SlideAppService.UpdateAsync(
                Slide.Id,
                ObjectMapper.Map<EditSlideViewModel, CreateUpdateSlideDto>(Slide)
            );

            return NoContent();
        }

        public class EditSlideViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            public string Title { get; set; }
            public string Detail { get; set; }
            public float Sale { get; set; }
        }
    }
}
