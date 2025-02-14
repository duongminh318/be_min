using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatedDBByEFCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
