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
            // ADD a NEW MAPPING

            CreateMap<Areas.Admin.Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();
            CreateMap<Areas.Admin.Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<Areas.Admin.Pages.Slides.CreateModalModel.CreateSlideViewModel, CreateUpdateSlideDto>();

            // ADD THESE NEW MAPPINGS
            CreateMap<AuthorDto, Areas.Admin.Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Areas.Admin.Pages.Authors.EditModalModel.EditAuthorViewModel,UpdateAuthorDto>();


            CreateMap<BookDto, Areas.Admin.Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Areas.Admin.Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            CreateMap<SlideDto, Areas.Admin.Pages.Slides.EditModalModel.EditSlideViewModel>();
            CreateMap<Areas.Admin.Pages.Slides.EditModalModel.EditSlideViewModel,CreateUpdateSlideDto>();

        }
    }
}
