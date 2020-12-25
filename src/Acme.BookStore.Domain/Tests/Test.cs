using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Tests
{
    public class Test : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

    }
}