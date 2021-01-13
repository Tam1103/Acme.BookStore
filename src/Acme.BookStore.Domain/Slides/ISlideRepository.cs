using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Slides
{
    public interface ISlideRepository : IRepository<Slide, Guid>
    {
        Task<Slide> FindByNameAsync(string name);

        Task<List<Slide>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
