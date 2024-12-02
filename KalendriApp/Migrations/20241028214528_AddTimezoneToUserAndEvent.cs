using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KalendriApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTimezoneToUserAndEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "User",
                newName: "Timezone");

            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "Event",
                newName: "Timezone");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "#FF0000", "Работа" },
                    { 2, "#00FF00", "Личное" },
                    { 3, "#0000FF", "Семья" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Timezone" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "adminpassword", "Europe/Tallinn" },
                    { 2, "user@example.com", "User", "userpassword", "Europe/Tallinn" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CategoryId", "Description", "EndDateTime", "Recurrence", "Reminder", "StartDateTime", "Timezone", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Обсуждение проекта", new DateTime(2024, 10, 30, 1, 45, 26, 989, DateTimeKind.Local).AddTicks(3241), "none", "email", new DateTime(2024, 10, 29, 23, 45, 26, 989, DateTimeKind.Local).AddTicks(3183), "Europe/Tallinn", "Встреча с командой", 1 },
                    { 2, 2, "День рождения друга", new DateTime(2024, 10, 31, 2, 45, 26, 989, DateTimeKind.Local).AddTicks(3254), "yearly", "notification", new DateTime(2024, 10, 30, 23, 45, 26, 989, DateTimeKind.Local).AddTicks(3251), "Europe/Tallinn", "День рождения", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Timezone",
                table: "User",
                newName: "TimeZone");

            migrationBuilder.RenameColumn(
                name: "Timezone",
                table: "Event",
                newName: "TimeZone");
        }
    }
}
