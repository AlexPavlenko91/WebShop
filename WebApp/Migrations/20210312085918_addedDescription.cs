using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class addedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("196b7b3d-03ab-4e41-82bb-726fded19aec"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("4e194d2e-fef9-4ecc-bc1f-edf151aa7858"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("9ecf7e90-4486-4370-a76f-bf26e1b3391c"));

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "goods",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("3a7f814d-7cb9-4390-a256-f63ee4c454c8"), "Пиво разливное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("b8732f78-8801-4589-b12e-c6e0605719c5"), "Пиво бутылочное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("86cdb0d6-b5a6-4b94-95bc-d940532e5a92"), "Снеки" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("3a7f814d-7cb9-4390-a256-f63ee4c454c8"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("86cdb0d6-b5a6-4b94-95bc-d940532e5a92"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("b8732f78-8801-4589-b12e-c6e0605719c5"));

            migrationBuilder.DropColumn(
                name: "description",
                table: "goods");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("196b7b3d-03ab-4e41-82bb-726fded19aec"), "Пиво разливное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("9ecf7e90-4486-4370-a76f-bf26e1b3391c"), "Пиво бутылочное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("4e194d2e-fef9-4ecc-bc1f-edf151aa7858"), "Снеки" });
        }
    }
}
