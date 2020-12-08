﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Slides
{
    public class Slide : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public float Sale { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

    }
}
