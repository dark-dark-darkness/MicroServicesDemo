using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroServicesDemo.PlatformsService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    publisher = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_platform", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "t_platform",
                columns: new[] { "id", "cost", "name", "publisher" },
                values: new object[,]
                {
                    { new Guid("08db7272-6ae3-bbc5-0015-5dd9eab40000"), "Free", "Dot Net", "Microsoft" },
                    { new Guid("08db7272-6ae3-bbce-0015-5dd9eab40000"), "Free", "SQL Server Express", "Microsoft" },
                    { new Guid("08db7272-6ae3-bbcf-0015-5dd9eab40000"), "Free", "Kubernetes", "Cloud Native Computing Foundation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_platform");
        }
    }
}
