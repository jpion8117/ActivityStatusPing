using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityStatusPing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "LastActive", "Username" },
                values: new object[] { 1, new DateTime(2023, 11, 20, 0, 37, 3, 180, DateTimeKind.Utc).AddTicks(1619), "Josh" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "LastActive", "Username" },
                values: new object[] { 2, new DateTime(2023, 11, 20, 0, 37, 3, 180, DateTimeKind.Utc).AddTicks(1620), "Michelle" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "LastActive", "Username" },
                values: new object[] { 3, new DateTime(2023, 11, 20, 0, 37, 3, 180, DateTimeKind.Utc).AddTicks(1621), "Shane" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
