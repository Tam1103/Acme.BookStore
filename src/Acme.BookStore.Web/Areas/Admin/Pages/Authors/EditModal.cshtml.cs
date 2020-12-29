using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Areas.Admin.Pages.Authors
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditAuthorViewModel Author { get; set; }

        private readonly IAuthorAppService _authorAppService;

        public EditModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var authorDto = await _authorAppService.GetAsync(id);
            Author = ObjectMapper.Map<AuthorDto, EditAuthorViewModel>(authorDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorAppService.UpdateAsync(
                Author.Id,
                ObjectMapper.Map<EditAuthorViewModel, UpdateAuthorDto>(Author)
            );

            return NoContent();
        }

        public class EditAuthorViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }


            [StringLength(AuthorConsts.MaxNameLength)]
            public string Name { get; set; }


            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; } = DateTime.Now;

            [TextArea]
            public string ShortBio { get; set; }
        }
    }
}
