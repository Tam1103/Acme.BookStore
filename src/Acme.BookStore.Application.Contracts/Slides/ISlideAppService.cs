using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Acme.BookStore.Slides
{
    public interface ISlideAppService :
        ICrudAppService< //Defines CRUD methods
            SlideDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSlideDto> //Used to create/update a book 
    {
        // ADD the NEW METHOD
    }
}