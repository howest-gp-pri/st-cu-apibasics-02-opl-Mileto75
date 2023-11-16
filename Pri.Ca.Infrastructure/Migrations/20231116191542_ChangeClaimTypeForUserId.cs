using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    public partial class ChangeClaimTypeForUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELKxUVozfH4gWYTe2RmBuHN9je6qsRmaorbu+We0cpnbYZ0jX88nFezbvTH37WSqXA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAUmtNysN1totpRFL+IGabRvVB6Du7NikD4JTI5uDy5ql0NVpXZ7qioFRadFg/bmxQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClaimType",
                value: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

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
    }
}
