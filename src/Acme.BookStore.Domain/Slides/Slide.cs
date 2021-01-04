using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Slides
{
    public class Slide : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public float Sale { get; set; }
    }
}
