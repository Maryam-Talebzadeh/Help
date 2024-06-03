using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EditProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Proposals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 821, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 6, 1, 11, 19, 46, 827, DateTimeKind.Local).AddTicks(5432), new DateTime(2024, 6, 1, 11, 19, 46, 827, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 10, 1, 11, 19, 46, 827, DateTimeKind.Local).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 842, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 828, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 837, DateTimeKind.Local).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 835, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 866, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 866, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 866, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 866, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 871, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 838, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 838, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 838, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 1, 11, 19, 46, 880, DateTimeKind.Local).AddTicks(7345));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Proposals");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 860, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 31, 9, 40, 59, 862, DateTimeKind.Local).AddTicks(9224), new DateTime(2024, 5, 31, 9, 40, 59, 862, DateTimeKind.Local).AddTicks(9240), new DateTime(2024, 9, 30, 9, 40, 59, 862, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 872, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 863, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 869, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 868, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 885, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 885, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 885, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 885, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 887, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 870, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 870, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 870, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 40, 59, 892, DateTimeKind.Local).AddTicks(521));
        }
    }
}
