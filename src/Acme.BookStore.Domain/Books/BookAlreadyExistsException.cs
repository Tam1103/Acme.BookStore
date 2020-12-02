using Volo.Abp;

namespace Acme.BookStore.Books
{
    public class BookAlreadyExistsException : BusinessException
    {
        public BookAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
