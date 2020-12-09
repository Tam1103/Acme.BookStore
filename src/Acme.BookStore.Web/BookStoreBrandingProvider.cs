using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.Web
{
    [Dependency(ReplaceServices = true)]
    public class BookStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BookStore";
        public override string LogoUrl => "src/Acme.BookStore.Web/wwwroot/img/CV.jpg";
        public override string LogoReverseUrl => LogoUrl;
    }   
}
