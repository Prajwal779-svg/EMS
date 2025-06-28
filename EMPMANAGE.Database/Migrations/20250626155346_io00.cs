using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPMANAGE.Database.Migrations
{
    /// <inheritdoc />
    public partial class io00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "HireDate", "Name", "Position", "Salary" },
                values: new object[] { 1, "IT", "mary@pragimtech.com", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mary", "Developer", 60000.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
