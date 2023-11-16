using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    public partial class AddBirthDateToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "DateOfBirth", "PasswordHash" },
                values: new object[] { new DateTime(1972, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEDvMkb82Cn7uifSnaTnIqPVtr+QoekKu1cRDvXuHCZI1SQKDbWs0QqV7B8Di4ytJFw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "DateOfBirth", "PasswordHash" },
                values: new object[] { new DateTime(1975, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAECBzt8Tt8cVWCNPRie4cBySR8x1ypCoOWvHy+mDTgCNaeHNAAW6O0bk1BVBB48/PGw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECBTiPf2DitbCoY1xHygMv5bJZcqGw17JPoUZvDHgvSZeEZwKCxPav3T8o1wr640SQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEC+WIJD2958zqOzrgBEMusF/FjaG2DKz/mEDxCW2aYiflQMzAMTZmkxNBguoDdFHug==");
        }
    }
}
