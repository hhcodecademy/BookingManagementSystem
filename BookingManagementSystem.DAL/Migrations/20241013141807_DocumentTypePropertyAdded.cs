using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DocumentTypePropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Documents");
        }
    }
}
