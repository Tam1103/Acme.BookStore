using System;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace Acme.BookStore.Authors
{
    public class AuthorAppService :
       CrudAppService<
           Author, //The author entity
           AuthorDto, //Used to show authors
           Guid, //Primary key of the author entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateAuthorDto>, //Used to create/update a author
       IAuthorAppService //implement the IAppService
    {
        public AuthorAppService(
            IRepository<Author, Guid> repository)
            : base(repository)
        {
            GetPolicyName = BookStorePermissions.Authors.Default;
            GetListPolicyName = BookStorePermissions.Authors.Default;
            CreatePolicyName = BookStorePermissions.Authors.Create;
            UpdatePolicyName = BookStorePermissions.Authors.Edit;
            DeletePolicyName = BookStorePermissions.Authors.Delete;
        }
    }
}
