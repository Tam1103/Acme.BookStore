using Acme.BookStore.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages
{
    public abstract class BookStorePageModel : AbpPageModel
    {
        public IWebHostEnvironment _hostingEnvironment;
        protected BookStorePageModel()
        {
            LocalizationResourceType = typeof(BookStoreResource);
        }

        public string ImageUpload(IFormFile file, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            if (file == null)
            {
                return " ";
            }
            var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + file.FileName;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyToAsync(stream);
            return fileName;

        }
    }
}