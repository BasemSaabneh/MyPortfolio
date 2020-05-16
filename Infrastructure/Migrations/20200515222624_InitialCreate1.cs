using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "Id",
                keyValue: new Guid("ed85d323-d9ac-4ac6-a14f-6481a1925ede"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Owner",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "Profile" },
                values: new object[] { new Guid("4c31b7ca-3a7e-4eb0-ba0d-8d8b37c3134f"), null, "avatar.jpg", "Basem Saabneh", "Full Stack Developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AddressId",
                table: "Owner",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Address_AddressId",
                table: "Owner",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Address_AddressId",
                table: "Owner");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Owner_AddressId",
                table: "Owner");

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "Id",
                keyValue: new Guid("4c31b7ca-3a7e-4eb0-ba0d-8d8b37c3134f"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Owner");

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Avatar", "FullName", "Profile" },
                values: new object[] { new Guid("ed85d323-d9ac-4ac6-a14f-6481a1925ede"), "avatar.jpg", "Basem Saabneh", "Full Stack Developer" });
        }
    }
}
