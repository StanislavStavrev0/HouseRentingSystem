using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniquePhoneConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfe60478-d0ef-4e62-82d1-d9f0e8e17ed2", "AQAAAAEAACcQAAAAELJGrt8y4UgizgJZkEXUMpL/5g1eK05IpNVv5h5oZjIULm6xfd7tScAYJJfS17SpAg==", "2b1d2c29-81c2-4703-a978-7b29c63e5204" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3275923-635b-495b-812f-bfb37452dba4", "AQAAAAEAACcQAAAAEMji33BfdCpihtGXb9ll3FIr7E25pYYiP81SKSD6L/ve1OlhzgpEms0pZGaItLo6+A==", "3c05190a-fef2-4425-9ff3-de6c1bb3d7e8" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0811541d-608c-41a6-9eb3-a0b1df4aec78", "AQAAAAEAACcQAAAAEBh7NwY0VuB6PPg66wdYdNYZdEY4UHolb9OBDlAC5XpsTqqh/QhP122Ojw80WubtrQ==", "c623c4bb-86e9-4f49-b0ab-85d458962df4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a8d1699-17f7-45a6-b260-4526ded10ced", "AQAAAAEAACcQAAAAEErRQwAOMGEs2caEEyQ9crAy6vupJllMr26zWKahOtAqotvr+1r+HEXds5re6Rq27Q==", "62fc576c-363f-4efa-8809-a5a0cfd5028b" });
        }
    }
}
