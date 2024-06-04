using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EditVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    HelpRequestId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<short>(type: "smallint", nullable: false),
                    Mode = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Customers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ReceiverId",
                table: "Vote",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

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
    }
}
