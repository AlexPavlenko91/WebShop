using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class DbContextJokes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("0409f866-4941-4c5f-acce-6e3265dd71cf"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("48df9286-08c0-4d06-bea9-fc97041cb3f9"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("6d19d5ff-fa61-4ee3-bf2c-c7ce4e29e552"));

            migrationBuilder.CreateTable(
                name: "Jokes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jokes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("1caa2c91-37af-4c07-8984-d6958883d171"), "Пиво разливное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("67975c56-ea56-4a9b-9de3-ddcd9818ad26"), "Пиво бутылочное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("b57ab58f-e7da-40c2-9511-4dc3f770ec5b"), "Снеки" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jokes");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("1caa2c91-37af-4c07-8984-d6958883d171"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("67975c56-ea56-4a9b-9de3-ddcd9818ad26"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("b57ab58f-e7da-40c2-9511-4dc3f770ec5b"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("48df9286-08c0-4d06-bea9-fc97041cb3f9"), "Пиво разливное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("0409f866-4941-4c5f-acce-6e3265dd71cf"), "Пиво бутылочное" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("6d19d5ff-fa61-4ee3-bf2c-c7ce4e29e552"), "Снеки" });
        }
    }
}
