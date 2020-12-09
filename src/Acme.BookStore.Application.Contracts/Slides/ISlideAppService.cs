﻿using System;
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
    }
}