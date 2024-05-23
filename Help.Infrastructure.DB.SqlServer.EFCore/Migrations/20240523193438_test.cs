using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpServicePictures_HelpServices_ServiceId",
                table: "HelpServicePictures");

            migrationBuilder.DropIndex(
                name: "IX_HelpServicePictures_ServiceId",
                table: "HelpServicePictures");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "HelpServicePictures");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlleyNumber", "CreationDate" },
                values: new object[] { 1, new DateTime(2024, 5, 23, 12, 34, 35, 911, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 23, 12, 34, 35, 915, DateTimeKind.Local).AddTicks(2284), new DateTime(2024, 5, 23, 12, 34, 35, 915, DateTimeKind.Local).AddTicks(2306), new DateTime(2024, 9, 23, 12, 34, 35, 915, DateTimeKind.Local).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 924, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 916, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 922, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 921, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 935, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 935, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 935, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 935, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "PictureId" },
                values: new object[] { new DateTime(2024, 5, 23, 12, 34, 35, 936, DateTimeKind.Local).AddTicks(8725), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 923, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 923, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 923, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 12, 34, 35, 943, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.CreateIndex(
                name: "IX_HelpServices_PictureId",
                table: "HelpServices",
                column: "PictureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HelpServices_HelpServicePictures_PictureId",
                table: "HelpServices",
                column: "PictureId",
                principalTable: "HelpServicePictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpServices_HelpServicePictures_PictureId",
                table: "HelpServices");

            migrationBuilder.DropIndex(
                name: "IX_HelpServices_PictureId",
                table: "HelpServices");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "HelpServicePictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlleyNumber", "CreationDate" },
                values: new object[] { 0, new DateTime(2024, 5, 23, 0, 56, 27, 841, DateTimeKind.Local).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 56, 27, 842, DateTimeKind.Local).AddTicks(8769), new DateTime(2024, 5, 23, 0, 56, 27, 842, DateTimeKind.Local).AddTicks(8776), new DateTime(2024, 9, 23, 0, 56, 27, 842, DateTimeKind.Local).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 846, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 843, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 845, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 845, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 872, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 872, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 872, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 872, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "PictureId" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 56, 27, 873, DateTimeKind.Local).AddTicks(5398), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 845, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 845, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 845, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 23, 0, 56, 27, 880, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.CreateIndex(
                name: "IX_HelpServicePictures_ServiceId",
                table: "HelpServicePictures",
                column: "ServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HelpServicePictures_HelpServices_ServiceId",
                table: "HelpServicePictures",
                column: "ServiceId",
                principalTable: "HelpServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
