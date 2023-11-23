using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    public partial class seedingDoB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClaimValue",
                value: "12/12/2010");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBugCGIe8EcZw2Keqo/Iw6dmt8uY+IpJ1KnISo6XB3hc9Leh9tTHq05ZGP4otsXKnA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "DateOfBirth", "PasswordHash" },
                values: new object[] { new DateTime(2010, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEL2iF2H5wGsJlOBrSX3dR2v5KtmV+lE2l4U1UC+eL0sNHzeZ0ZaAIJDDoSPfagBdAw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClaimValue",
                value: "12/12/1975");

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
                columns: new[] { "DateOfBirth", "PasswordHash" },
                values: new object[] { new DateTime(1975, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEAUmtNysN1totpRFL+IGabRvVB6Du7NikD4JTI5uDy5ql0NVpXZ7qioFRadFg/bmxQ==" });
        }
    }
}
