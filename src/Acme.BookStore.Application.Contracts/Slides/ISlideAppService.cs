﻿using Microsoft.AspNetCore.Http;
using System;
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