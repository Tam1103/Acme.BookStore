using Acme.BookStore.Books;
using AutoMapper;
using Acme.BookStore.Authors;
using Acme.BookStore.Slides;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<BookDto, CreateUpdateBookDto>();
            CreateMap<SlideDto, CreateUpdateSlideDto>();
            CreateMap<AuthorDto, CreateUpdateAuthorDto>();
            // ADD a NEW MAPPING

            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateUpdateAuthorDto>();
            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<Pages.Slides.CreateModalModel.CreateSlideViewModel, CreateUpdateSlideDto>();

            // ADD THESE NEW MAPPINGS
            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,CreateUpdateAuthorDto>();


            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            CreateMap<SlideDto, Pages.Slides.EditModalModel.EditSlideViewModel>();
            CreateMap<Pages.Slides.EditModalModel.EditSlideViewModel,CreateUpdateSlideDto>();

        }
    }
}
