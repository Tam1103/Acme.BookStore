using Acme.BookStore.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Slides
{
    public class SlideAppService :
        CrudAppService<
            Slide, //The Book entity
            SlideDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSlideDto>, //Used to create/update a book
        ISlideAppService //implement the ISlideAppService
    {
        private readonly ISlideAppService _slideAppService;

        public SlideAppService(
            IRepository<Slide, Guid> repository,
            ISlideAppService slideAppService)
            : base(repository)
        {
            _slideAppService = slideAppService;
            GetPolicyName = BookStorePermissions.Slides.Default;
            GetListPolicyName = BookStorePermissions.Slides.Default;
            CreatePolicyName = BookStorePermissions.Slides.Create;
            UpdatePolicyName = BookStorePermissions.Slides.Edit;
            DeletePolicyName = BookStorePermissions.Slides.Create;
        }

        public override async Task<SlideDto> GetAsync(Guid id)
            => await _slideAppService.GetAsync(id);
        public override async Task<PagedResultDto<SlideDto>> GetListAsync(PagedAndSortedResultRequestDto input)
            => await _slideAppService.GetListAsync(input);
    }
}
