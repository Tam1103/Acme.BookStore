using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Photos
{
   public class Photo: FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
