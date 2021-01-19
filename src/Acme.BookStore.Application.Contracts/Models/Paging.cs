using Acme.BookStore.Books;
namespace Acme.BookStore.Models
{
    public class Paging
    {
        public const int maxPageSize = 4;
        public static int PageNumber { get; set; } = 1;

        public static GetBookListDto filter;

        public static void Filter()
        {
            filter = new GetBookListDto
            {
                SkipCount = (PageNumber - 1) * maxPageSize,//Ignore the number
                MaxResultCount = maxPageSize
            };
        }
    }
}
