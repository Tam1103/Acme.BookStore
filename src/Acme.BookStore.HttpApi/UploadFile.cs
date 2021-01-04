using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Acme.BookStore
{
   public class UploadFile
    {
        public static IWebHostEnvironment _iWebHostingEnvironment;
        public string ImageUpload(IFormFile file, IWebHostEnvironment hostingEnvironment)
        {
            _iWebHostingEnvironment = hostingEnvironment;
            if (file == null)
            {
                throw new ArgumentException();
            }
            var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + file.FileName;
            var path = Path.Combine(_iWebHostingEnvironment.WebRootPath, "images", fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyToAsync(stream);
            return fileName;
        }
    }
}
