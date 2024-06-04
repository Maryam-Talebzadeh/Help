using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Vote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "ExpertScore",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequesterScore",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 922, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 48, 53, 924, DateTimeKind.Local).AddTicks(3594), new DateTime(2024, 6, 3, 0, 48, 53, 924, DateTimeKind.Local).AddTicks(3603), new DateTime(2024, 10, 3, 0, 48, 53, 924, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 930, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 924, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 929, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ExpertScore", "RequesterScore" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 48, 53, 928, DateTimeKind.Local).AddTicks(6128), "0,0,0,0,0", "0,0,0,0,0" });

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 948, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 948, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 948, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 948, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 949, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 929, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 929, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 929, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 0, 48, 53, 953, DateTimeKind.Local).AddTicks(738));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertScore",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RequesterScore",
                table: "Customers");

            migrationBuilder.AddColumn<short>(
                name: "Score",
                table: "Customers",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Score",
                table: "Comments",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

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
                columns: new[] { "CreationDate", "Score" },
                values: new object[] { new DateTime(2024, 6, 1, 11, 19, 46, 835, DateTimeKind.Local).AddTicks(1776), (short)0 });

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
    }
}
