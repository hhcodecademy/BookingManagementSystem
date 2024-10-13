using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DocumentModelAddedForRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RoomId",
                table: "Documents",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Rooms_RoomId",
                table: "Documents",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Rooms_RoomId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_RoomId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Documents");
        }
    }
}
