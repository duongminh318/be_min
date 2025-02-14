using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatedDBByEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAtrributeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_AttributeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AttributeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AttributeTypeId",
                table: "Attributes",
                column: "AttributeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "AttributeTypes");
        }
    }
}
