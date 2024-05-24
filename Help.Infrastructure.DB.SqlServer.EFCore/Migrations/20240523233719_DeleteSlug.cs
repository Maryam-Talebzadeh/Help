using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "HelpRequests");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 228, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 23, 16, 37, 17, 230, DateTimeKind.Local).AddTicks(9642), new DateTime(2024, 5, 23, 16, 37, 17, 230, DateTimeKind.Local).AddTicks(9654), new DateTime(2024, 9, 23, 16, 37, 17, 230, DateTimeKind.Local).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 235, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 231, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 234, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 233, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 239, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 239, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 239, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 239, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 240, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 234, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 234, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 234, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 16, 37, 17, 242, DateTimeKind.Local).AddTicks(5911));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "HelpRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 88, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 23, 12, 45, 29, 91, DateTimeKind.Local).AddTicks(9442), new DateTime(2024, 5, 23, 12, 45, 29, 91, DateTimeKind.Local).AddTicks(9458), new DateTime(2024, 9, 23, 12, 45, 29, 91, DateTimeKind.Local).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 100, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 92, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 97, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 96, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 113, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 113, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 113, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 113, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 116, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 98, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 99, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 99, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 45, 29, 132, DateTimeKind.Local).AddTicks(586));
        }
    }
}
