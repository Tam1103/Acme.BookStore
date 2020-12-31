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

            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/home";
            //        await next();
            //    }
            //});
            //app.Use(async (ctx, next) =>
            //{
            //    await next();

            //    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
            //    {
            //        //Re-execute the request so the user gets the error page
            //        string originalPath = ctx.Request.Path.Value;
            //        ctx.Items["originalPath"] = originalPath;
            //        ctx.Request.Path = "/home/error/404";
            //        await next();
            //    }
            //});
        }
    }
}