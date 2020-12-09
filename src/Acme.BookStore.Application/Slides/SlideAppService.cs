using Acme.BookStore.Slides;
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
            GetPolicyName = BookStorePermissions.Books.Default;
            GetListPolicyName = BookStorePermissions.Books.Default;
            CreatePolicyName = BookStorePermissions.Books.Create;
            UpdatePolicyName = BookStorePermissions.Books.Edit;
            DeletePolicyName = BookStorePermissions.Books.Create;
        }

        public async Task<SlideDto> GetAsync(Guid id)
        {
            var slide = await _slideAppService.GetAsync(id);
            return slide;
        }
        public async Task<PagedResultDto<SlideDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await _slideAppService.GetListAsync(input);
        }
    }
}
