using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Acme.BookStore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<BookStoreWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=error}/{id?}");
            });

            //app.Run(async context =>
            //{
            //     context.Response.Redirect("/home/error");
            //});
        }
    }
}