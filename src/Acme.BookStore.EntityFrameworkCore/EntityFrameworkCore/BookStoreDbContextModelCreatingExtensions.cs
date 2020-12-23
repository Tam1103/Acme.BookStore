using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Slides;
using Acme.BookStore.Tests;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BookStoreConsts.DbTablePrefix + "YourEntities", BookStoreConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Book>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Books", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BookConsts.MaxNameLength);

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Authors", BookStoreConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });


            builder.Entity<Slide>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Slides", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(SlideConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });



            builder.Entity<Test>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Tests", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(SlideConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });

            builder.Entity<Slide>(b =>
                    {
                        b.ToTable(BookStoreConsts.DbTablePrefix + "Photos", BookStoreConsts.DbSchema);
                        b.ConfigureByConvention(); //auto configure for the base class props
                    });

        }
    }
}