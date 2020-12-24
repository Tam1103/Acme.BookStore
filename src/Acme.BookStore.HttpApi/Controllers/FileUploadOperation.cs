namespace Acme.BookStore.Controllers
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Net.Http.Headers;

    namespace MyProject
    {
        public static class FileUploadOperation
        {
            public static string GetFileName(this IFormFile file)
            {
                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                return Path.GetFileName(fileContent.FileName.Trim('"'));
            }
        }
    }
}
