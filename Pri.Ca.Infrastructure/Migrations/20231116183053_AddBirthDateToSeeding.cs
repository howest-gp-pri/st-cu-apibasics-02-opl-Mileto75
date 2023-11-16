using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    public partial class AddBirthDateToSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 5, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "12/12/1972", "1" },
                    { 6, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "12/12/1975", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK04SD4AaShxPSq/YHDL84GPJRsYyvszTOzg076vX4gT5RDAX4SS7Jv5XFttWM6DUQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDv3HDnOtDIbpcptILMlcUlQwaxqXI5LwUVgBsu0Cf920eeIE15LKH9WkNzT3Bp2Gg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDvMkb82Cn7uifSnaTnIqPVtr+QoekKu1cRDvXuHCZI1SQKDbWs0QqV7B8Di4ytJFw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECBzt8Tt8cVWCNPRie4cBySR8x1ypCoOWvHy+mDTgCNaeHNAAW6O0bk1BVBB48/PGw==");
        }
    }
}
