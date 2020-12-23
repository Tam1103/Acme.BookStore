using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSlides",
                table: "AppSlides");

            migrationBuilder.RenameTable(
                name: "AppSlides",
                newName: "AppPhotos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppBooks",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppPhotos",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPhotos",
                table: "AppPhotos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppPhotos_Name",
                table: "AppPhotos",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPhotos",
                table: "AppPhotos");

            migrationBuilder.DropIndex(
                name: "IX_AppPhotos_Name",
                table: "AppPhotos");

            migrationBuilder.RenameTable(
                name: "AppPhotos",
                newName: "AppSlides");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppBooks",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppSlides",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSlides",
                table: "AppSlides",
                column: "Id");
        }
    }
}
