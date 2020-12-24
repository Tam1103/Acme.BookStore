using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Acme.BookStore.Slides
{
    public interface ISlideAppService :
        ICrudAppService<
            SlideDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateSlideDto>
    {
        Task<List<SlideDto>> CreateSlide(IFormFile file);
    }
}