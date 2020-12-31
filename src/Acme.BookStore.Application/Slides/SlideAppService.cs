using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
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
        ISlideAppService//implement the ISlideAppService
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
        public async Task<SlideDto> CreateUploadFile(IFormFile file, string title, string detail, float price)
        {
            UploadFile upload = new UploadFile();
            string fileName = upload.ImageUpload(file, _iHostEnvironment);
            var slide = new Slide
            {
                Name = fileName,
                Title = title,
                Detail = detail,
                Sale = price
            };
            await Repository.InsertAsync(slide);
            return ObjectMapper.Map<Slide, SlideDto>(slide);
        }
        public async Task UpdateUploadFile(Guid id, IFormFile file, string title, string detail, float price)
        {
            var slide = await Repository.GetAsync(id);
            UploadFile upload = new UploadFile();
            string fileName = upload.ImageUpload(file, _iHostEnvironment);
         
            slide.Name = fileName;
            slide.Title = title;
            slide.Sale = price;
            slide.Detail = detail;
            await Repository.UpdateAsync(slide);
        }

    }
}
