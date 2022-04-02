using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loanApp.Migrations
{
    public partial class loansdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    State = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Industry = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ProfileUpdated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBanks",
                columns: table => new
                {
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CompanyBanks_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDocuments",
                columns: table => new
                {
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyBranch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ReferenceNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepaymentPlan = table.Column<int>(type: "int", nullable: false),
                    TimelineType = table.Column<int>(type: "int", nullable: false),
                    PurposeForLoan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ReferenceNumber);
                    table.ForeignKey(
                        name: "FK_Loans_Banks_BankID",
                        column: x => x.BankID,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LoanApplicationReferenceNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Documents_Loans_LoanApplicationReferenceNumber",
                        column: x => x.LoanApplicationReferenceNumber,
                        principalTable: "Loans",
                        principalColumn: "ReferenceNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBanks_CompanyUserID",
                table: "CompanyBanks",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_CompanyUserID",
                table: "CompanyDocuments",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressID",
                table: "Contacts",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyUserID",
                table: "Contacts",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LoanApplicationReferenceNumber",
                table: "Documents",
                column: "LoanApplicationReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BankID",
                table: "Loans",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CompanyUserID",
                table: "Loans",
                column: "CompanyUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBanks");

            migrationBuilder.DropTable(
                name: "CompanyDocuments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CompanyUsers");
        }
    }
}
