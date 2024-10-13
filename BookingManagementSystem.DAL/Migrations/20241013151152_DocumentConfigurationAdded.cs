using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DocumentConfigurationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Hotels_HotelId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Rooms_RoomId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_HotelId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_RoomId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerId",
                table: "Documents",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Hotels_OwnerId",
                table: "Documents",
                column: "OwnerId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Rooms_OwnerId",
                table: "Documents",
                column: "OwnerId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Hotels_OwnerId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Rooms_OwnerId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_OwnerId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HotelId",
                table: "Documents",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RoomId",
                table: "Documents",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Hotels_HotelId",
                table: "Documents",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Rooms_RoomId",
                table: "Documents",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
