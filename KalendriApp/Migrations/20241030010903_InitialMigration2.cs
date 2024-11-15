using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalendriApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2024, 10, 31, 5, 9, 2, 70, DateTimeKind.Local).AddTicks(5198), new DateTime(2024, 10, 31, 3, 9, 2, 70, DateTimeKind.Local).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2024, 11, 1, 6, 9, 2, 70, DateTimeKind.Local).AddTicks(5249), new DateTime(2024, 11, 1, 3, 9, 2, 70, DateTimeKind.Local).AddTicks(5246) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$fVX.lzIZUK63ay0mARZ1vOEgh.mfBVEDHivuboiNRoULrzqN2JL/2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$QFzbINr4Xad1UpGO/wQJT.yOd6x9gZ1w7Zspyk4IRAGXtQGd2CfWy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2024, 10, 30, 1, 45, 26, 989, DateTimeKind.Local).AddTicks(3241), new DateTime(2024, 10, 29, 23, 45, 26, 989, DateTimeKind.Local).AddTicks(3183) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2024, 10, 31, 2, 45, 26, 989, DateTimeKind.Local).AddTicks(3254), new DateTime(2024, 10, 30, 23, 45, 26, 989, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "adminpassword");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "userpassword");
        }
    }
}
