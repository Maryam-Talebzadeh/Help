using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.CreateTable(
                name: "CustomerHelpService",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHelpService", x => new { x.CustomersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CustomerHelpService_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerHelpService_HelpServices_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "HelpServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 594, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfEmployeement", "TerminationDateContract" },
                values: new object[] { new DateTime(2024, 5, 31, 9, 14, 43, 595, DateTimeKind.Local).AddTicks(9217), new DateTime(2024, 5, 31, 9, 14, 43, 595, DateTimeKind.Local).AddTicks(9225), new DateTime(2024, 9, 30, 9, 14, 43, 595, DateTimeKind.Local).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 599, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 596, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "CustomerPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 598, DateTimeKind.Local).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 598, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 603, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 603, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 603, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "HelpRequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 603, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "HelpServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 604, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 598, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 598, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 598, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 31, 9, 14, 43, 605, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHelpService_SkillsId",
                table: "CustomerHelpService",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerHelpService");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_HelpServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "HelpServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CustomerId",
                table: "Skills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ServiceId",
                table: "Skills",
                column: "ServiceId");
        }
    }
}
