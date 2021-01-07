using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Authors
{
    public interface IAuthorAppService : ICrudAppService< //Defines CRUD methods
            AuthorDto, //Used to show author
            Guid, //Primary key of the author entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateAuthorDto> //Used to create/update a author 
    {

    }
}

