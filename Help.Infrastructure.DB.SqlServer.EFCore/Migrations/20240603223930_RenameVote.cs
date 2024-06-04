using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RenameVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Customers_ReceiverId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_ReceiverId",
                table: "Votes",
                newName: "IX_Votes_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 910, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 6, 3, 15, 39, 22, 914, DateTimeKind.Local).AddTicks(4797), new DateTime(2024, 6, 3, 15, 39, 22, 914, DateTimeKind.Local).AddTicks(4821), new DateTime(2024, 10, 3, 15, 39, 22, 914, DateTimeKind.Local).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 927, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 916, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 924, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 923, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 940, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 940, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 940, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 940, DateTimeKind.Local).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 942, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 925, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 925, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 925, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 15, 39, 22, 947, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Customers_ReceiverId",
                table: "Votes",
                column: "ReceiverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Customers_ReceiverId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_ReceiverId",
                table: "Vote",
                newName: "IX_Vote_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 55, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 6, 3, 1, 32, 47, 58, DateTimeKind.Local).AddTicks(8732), new DateTime(2024, 6, 3, 1, 32, 47, 58, DateTimeKind.Local).AddTicks(8756), new DateTime(2024, 10, 3, 1, 32, 47, 58, DateTimeKind.Local).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 71, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 59, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 68, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 66, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 85, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 85, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 85, DateTimeKind.Local).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 85, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 88, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 69, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 69, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 69, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 3, 1, 32, 47, 93, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Customers_ReceiverId",
                table: "Vote",
                column: "ReceiverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
