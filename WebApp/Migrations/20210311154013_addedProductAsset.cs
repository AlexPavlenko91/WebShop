using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class addedProductAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goods_Assets_PhotoId",
                table: "goods");

            migrationBuilder.DropTable(
                name: "Jokes");

            migrationBuilder.DropIndex(
                name: "IX_goods_PhotoId",
                table: "goods");

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

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "goods");

            migrationBuilder.CreateTable(
                name: "goods_assets",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    asset_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods_assets", x => new { x.product_id, x.asset_id });
                    table.ForeignKey(
                        name: "FK_goods_assets_Assets_asset_id",
                        column: x => x.asset_id,
                        principalTable: "Assets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goods_assets_goods_product_id",
                        column: x => x.product_id,
                        principalTable: "goods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_goods_assets_asset_id",
                table: "goods_assets",
                column: "asset_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goods_assets");

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

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "goods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jokes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JokeQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_goods_PhotoId",
                table: "goods",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_goods_Assets_PhotoId",
                table: "goods",
                column: "PhotoId",
                principalTable: "Assets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
