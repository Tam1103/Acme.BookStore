using Abp.AutoMapper;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Slides
{
    [AutoMapFrom(typeof(Slide))]
    public class Slide : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public float Sale { get; set; }
    }
}
