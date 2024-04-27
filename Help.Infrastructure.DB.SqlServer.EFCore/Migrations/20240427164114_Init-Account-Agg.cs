using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitAccountAgg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_HelpRequests_HelpRequestId",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "ExpertId",
                table: "Skills",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ExpertId",
                table: "Proposals",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "HelpRequests",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ExpertId",
                table: "Comments",
                newName: "CustomerRoleId");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "Comments",
                newName: "CustomerId");

            migrationBuilder.CreateTable(
                name: "CustomerRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<short>(type: "smallint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsExpert = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPictures_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CustomerId",
                table: "Skills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CustomerId",
                table: "Proposals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_CustomerId",
                table: "HelpRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerRoleId",
                table: "Comments",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPictures_CustomerId",
                table: "CustomerPictures",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomerRoles_CustomerRoleId",
                table: "Comments",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_Customers_CustomerId",
                table: "HelpRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Customers_CustomerId",
                table: "Proposals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_HelpRequests_HelpRequestId",
                table: "Proposals",
                column: "HelpRequestId",
                principalTable: "HelpRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Customers_CustomerId",
                table: "Skills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomerRoles_CustomerRoleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_Customers_CustomerId",
                table: "HelpRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Customers_CustomerId",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_HelpRequests_HelpRequestId",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Customers_CustomerId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "CustomerPictures");

            migrationBuilder.DropTable(
                name: "CustomerRoles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CustomerId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_CustomerId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_HelpRequests_CustomerId",
                table: "HelpRequests");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerRoleId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Skills",
                newName: "ExpertId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Proposals",
                newName: "ExpertId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "HelpRequests",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "CustomerRoleId",
                table: "Comments",
                newName: "ExpertId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Comments",
                newName: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_HelpRequests_HelpRequestId",
                table: "Proposals",
                column: "HelpRequestId",
                principalTable: "HelpRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
