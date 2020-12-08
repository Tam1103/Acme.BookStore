using System;
using Volo.Abp.Application.Dtos;
namespace Acme.BookStore.Slides
{
    public class SlideDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public float Sale { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Detail
        {
            get; set;
        }
    }
}
