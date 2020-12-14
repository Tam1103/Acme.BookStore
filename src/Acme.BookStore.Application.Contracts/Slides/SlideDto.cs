using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Slides
{
   public class SlideDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public float Sale { get; set; }

    }
}
