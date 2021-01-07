using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Slides
{
    public class CreateUpdateSlideDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Detail { get; set; }
        public float Sale { get; set; }
    }
}
