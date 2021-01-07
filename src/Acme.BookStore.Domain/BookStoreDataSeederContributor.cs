using System;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Slides;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Slide, Guid> _slideRepository;

        public BookStoreDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IRepository<Author, Guid> authorRepository,
            IRepository<Slide, Guid> slideRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _slideRepository = slideRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }
            var orwell = await _authorRepository.InsertAsync(
               new Author
               {
                   Name = "George Orwell",
                   BirthDate = new DateTime(1903, 06, 25),
                   ShortBio = "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
               },
                   autoSave: true
            );

            var douglas = await _authorRepository.InsertAsync(
                new Author
                {
                    Name = "Douglas Adams",
                    BirthDate = new DateTime(1952, 03, 11),
                    ShortBio = "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                },
                    autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = orwell.Id, // SET THE AUTHOR
                    Name = "1984",
                    Image = "CV.jpg",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = douglas.Id, // SET THE AUTHOR
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Image = "CV.jpg",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );

            await _slideRepository.InsertAsync(
               new Slide
               {
                   Name = "12102020112534images (3).jpg"
               },
               autoSave: true
                );

            await _slideRepository.InsertAsync(
                 new Slide
                 {
                     Name = "12112020024942images (4).jpg"
                 },
                 autoSave: true
               );

        }
    }
}
