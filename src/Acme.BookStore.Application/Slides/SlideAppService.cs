using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Core;

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

        public async Task<SlideDto> UploadFile(IFormFile file,string title,string detail, float price)
        {
                var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + file.FileName;
                var path = Path.Combine(this._iHostEnvironment.WebRootPath, "slides", fileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
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
    }
}
