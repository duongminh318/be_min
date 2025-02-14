using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatedDBByEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddFullDatabaseProductVariable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attributes");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttributeTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "AttributeValue",
                table: "Attributes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberInStock = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.CheckConstraint("CHK_Variant_Price", "[Price] >= 0");
                    table.CheckConstraint("CHK_Variant_Stock", "[NumberInStock] >= 0");
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantAttributes",
                columns: table => new
                {
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantAttributes", x => new { x.VariantId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_VariantAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantAttributes_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Product_BasePrice",
                table: "Products",
                sql: "[BasePrice] >= 0");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_Name",
                table: "AttributeTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AttributeValue_AttributeTypeId",
                table: "Attributes",
                columns: new[] { "AttributeValue", "AttributeTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VariantAttributes_AttributeId",
                table: "VariantAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_Name_ProductId",
                table: "Variants",
                columns: new[] { "Name", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariantAttributes");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Product_BasePrice",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AttributeTypes_Name",
                table: "AttributeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_AttributeValue_AttributeTypeId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "AttributeValue",
                table: "Attributes");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttributeTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attributes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
