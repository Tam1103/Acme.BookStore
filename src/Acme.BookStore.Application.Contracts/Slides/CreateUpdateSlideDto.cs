using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Slides
{
    public class CreateUpdateSlideDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Titile { get; set; }

        public string Detail { get; set; }
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
