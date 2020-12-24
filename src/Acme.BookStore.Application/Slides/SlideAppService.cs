using Acme.BookStore.Controllers.MyProject;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
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
        private readonly IWebHostEnvironment _iHostEnvironment;
        //private readonly IAuthorRepository _authorRepository;
        public SlideAppService(
            IRepository<Slide, Guid> repository,
            IWebHostEnvironment webHostEnvironment
         /*   IAuthorRepository authorRepository*/)
            : base(repository)
        {
            _iHostEnvironment = webHostEnvironment;
            //_authorRepository = authorRepository;
            GetPolicyName = BookStorePermissions.Slides.Default;
            GetListPolicyName = BookStorePermissions.Slides.Default;
            CreatePolicyName = BookStorePermissions.Slides.Create;
            UpdatePolicyName = BookStorePermissions.Slides.Edit;
            DeletePolicyName = BookStorePermissions.Slides.Delete;
        }

        public async Task<List<SlideDto>> CreateSlide(IFormFile file)
        {
            try
            {
                var fileName = file.GetFileName();
                var path = Path.Combine(this._iHostEnvironment.WebRootPath, "slide", fileName);
                var stream = new FileStream(path, FileMode.Create);

                var slides = new Slide
                {
                    Name = fileName,
                };
                await Repository.InsertAsync(slides);

                var slidess = await Repository.GetListAsync();
                return new List<SlideDto>(
                    ObjectMapper.Map<List<Slide>, List<SlideDto>>(slidess)
                );
            }

            catch (Exception)
            {
                throw new ArgumentNullException();
            }
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
