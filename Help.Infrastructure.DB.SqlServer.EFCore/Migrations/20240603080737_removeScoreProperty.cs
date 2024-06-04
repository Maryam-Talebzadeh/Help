using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class removeScoreProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertScore",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RequesterScore",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 527, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 6, 3, 1, 7, 35, 530, DateTimeKind.Local).AddTicks(2458), new DateTime(2024, 6, 3, 1, 7, 35, 530, DateTimeKind.Local).AddTicks(2472), new DateTime(2024, 10, 3, 1, 7, 35, 530, DateTimeKind.Local).AddTicks(2318) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 539, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 531, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 537, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 536, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 550, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 550, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 550, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 550, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 552, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 538, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 538, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 538, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 7, 35, 555, DateTimeKind.Local).AddTicks(9389));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
