using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


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
            IAuthorRepository authorRepository
            )
            : base(authorRepository)
        {
            GetPolicyName = BookStorePermissions.Authors.Default;
            GetListPolicyName = BookStorePermissions.Authors.Default;
            CreatePolicyName = BookStorePermissions.Authors.Create;
            UpdatePolicyName = BookStorePermissions.Authors.Edit;
            DeletePolicyName = BookStorePermissions.Authors.Delete;
        }


        [AllowAnonymous]
        public override Task<AuthorDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }
    }
}
