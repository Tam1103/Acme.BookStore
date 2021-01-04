using System.Threading.Tasks;
using Acme.BookStore.Localization;
using Acme.BookStore.MultiTenancy;
using Acme.BookStore.Permissions;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
namespace Acme.BookStore.Web.Menus
{
    public class BookStoreMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }
            var l = context.GetLocalizer<BookStoreResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("BookStore.Home", l["Menu:Home"], "~/"));

            var bookStoreMenu = new ApplicationMenuItem(
                "BooksStore",
                l["Menu:BookStore"],
                icon: "fas fa-chevron-circle-down"
            );

            //CHECK the PERMISSION
            if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
            {
                bookStoreMenu.AddItem(new ApplicationMenuItem(
                    "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/Books"
                ));
            }
            //CHECK the PERMISSION OF AUTHORS IN BOOKSTOREMENU CONTRIBUTOR
            if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                bookStoreMenu.AddItem(new ApplicationMenuItem(
                    "BooksStore.Authors",
                    l["Menu:Authors"],
                    url: "/Authors"
                ));
            }

            if (await context.IsGrantedAsync(BookStorePermissions.Slides.Default))
            {
                bookStoreMenu.AddItem(new ApplicationMenuItem(
                    "BooksStore.Slides",
                    l["Menu:Slides"],
                    url: "/Slides"
                ));
            }

            context.Menu.AddItem(bookStoreMenu);

            #region Login
            var loginStoreMenu = new ApplicationMenuItem(
              "loginStoreMenu",
              l["Login"],
              icon: "fas fa-sign-in-alt",
              url: "account/login"
          );

            if (!await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                context.Menu.AddItem(loginStoreMenu);
            }
            #endregion

            #region Category
                var categoryStoreMenu = new ApplicationMenuItem(
                "categoryStoreMenu",
                l["Menu:Category"],
                icon: "fa fa-book",
                url: "/Categorys"
            );
                context.Menu.AddItem(categoryStoreMenu);
            #endregion
        }
    }
}