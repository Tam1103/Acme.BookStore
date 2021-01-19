using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Slides
{
    public class GetSlideListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
