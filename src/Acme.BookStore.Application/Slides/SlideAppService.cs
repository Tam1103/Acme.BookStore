using Acme.BookStore.Authors;
using Acme.BookStore.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
namespace Acme.BookStore.Slides
{
    public class SlideAppService :
        CrudAppService<
            Slide, //The slide entity
            SlideDto, //Used to show slides
            Guid, //Primary key of the slide entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSlideDto>, //Used to create/update a slide
        ISlideAppService //implement the ISlideAppService
    {
        //private readonly IAuthorRepository _authorRepository;
        public SlideAppService(
            IRepository<Slide, Guid> repository
         /*   IAuthorRepository authorRepository*/)
            : base(repository)
        {
            //_authorRepository = authorRepository;
            GetPolicyName = BookStorePermissions.Slides.Default;
            GetListPolicyName = BookStorePermissions.Slides.Default;
            CreatePolicyName = BookStorePermissions.Slides.Create;
            UpdatePolicyName = BookStorePermissions.Slides.Edit;
            DeletePolicyName = BookStorePermissions.Slides.Delete;
        }

        //public override async Task<SlideDto> GetAsync(Guid id)
        //{
        //    var queryResult = await Repository.GetAsync(id);
        //    if (queryResult == null)
        //    {
        //        throw new EntityNotFoundException(typeof(Slide), id);
        //    }

        //    var slideDto = ObjectMapper.Map<Slide, SlideDto>(queryResult);
        //    return slideDto;
        //}

        //public override async Task<PagedResultDto<SlideDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        //{
        //    var slides = await Repository.GetListAsync();
        //    var totalCount = await Repository.GetCountAsync();
        //    return new PagedResultDto<SlideDto>(
        //        totalCount,
        //        ObjectMapper.Map<List<Slide>, List<SlideDto>>(slides)
        //    );
        //}
    }
}
