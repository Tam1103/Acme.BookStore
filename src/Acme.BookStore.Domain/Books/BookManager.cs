using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Books
{
    public class BookManager : DomainService
    {
        private readonly IBookRepository _authorRepository;

        public BookManager(IBookRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Book> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new BookAlreadyExistsException(name);
            }

            return new Book(
                GuidGenerator.Create(),
                name
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Book author,
            [NotNull] string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _authorRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != author.Id)
            {
                throw new BookAlreadyExistsException(newName);
            }

            Book.ChangeName(newName);
        }
    }
}
