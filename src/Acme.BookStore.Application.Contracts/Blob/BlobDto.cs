using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Blob
{
    public class BlobDto
    {
        public byte[] Content { get; set; }

        public string Name { get; set; }
    }
}
