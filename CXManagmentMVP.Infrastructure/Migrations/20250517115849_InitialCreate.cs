using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CXManagmentMVP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    CXAID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXAName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.CXAID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CXCustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCustomerFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CXCustomerEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CXCustomerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CXCustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    CXKeywordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXKeywordName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CXKeywordDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CXKeywordDataType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CXKeywordScoringFormula = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CXKeywordIsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.CXKeywordID);
                });

            migrationBuilder.CreateTable(
                name: "JourneyEvents",
                columns: table => new
                {
                    CXCJEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXASID = table.Column<int>(type: "int", nullable: true),
                    CXJEKeywordIDs = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CXJEStage = table.Column<int>(type: "int", nullable: true),
                    CXJEScoreSnapshot = table.Column<float>(type: "real", nullable: true),
                    CXJERequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CXJEFromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CXJEToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyEvents", x => x.CXCJEID);
                    table.ForeignKey(
                        name: "FK_JourneyEvents_Applications_CXASID",
                        column: x => x.CXASID,
                        principalTable: "Applications",
                        principalColumn: "CXAID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationKeywords",
                columns: table => new
                {
                    CXAKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXASID = table.Column<int>(type: "int", nullable: true),
                    CXKeywordID = table.Column<int>(type: "int", nullable: true),
                    CXAKWeight = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationKeywords", x => x.CXAKID);
                    table.ForeignKey(
                        name: "FK_ApplicationKeywords_Applications_CXASID",
                        column: x => x.CXASID,
                        principalTable: "Applications",
                        principalColumn: "CXAID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationKeywords_Keywords_CXKeywordID",
                        column: x => x.CXKeywordID,
                        principalTable: "Keywords",
                        principalColumn: "CXKeywordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAppKeywordScores",
                columns: table => new
                {
                    CXCAKScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCustomerID = table.Column<int>(type: "int", nullable: true),
                    CXASKID = table.Column<int>(type: "int", nullable: true),
                    CXCAKCalculatedScore = table.Column<float>(type: "real", nullable: true),
                    CXCAKCalculatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAppKeywordScores", x => x.CXCAKScoreID);
                    table.ForeignKey(
                        name: "FK_CustomerAppKeywordScores_ApplicationKeywords_CXASKID",
                        column: x => x.CXASKID,
                        principalTable: "ApplicationKeywords",
                        principalColumn: "CXAKID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAppKeywordScores_Customers_CXCustomerID",
                        column: x => x.CXCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CXCustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAppKeywordValues",
                columns: table => new
                {
                    CXCAKVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCustomerID = table.Column<int>(type: "int", nullable: true),
                    CXASKID = table.Column<int>(type: "int", nullable: true),
                    CXCAKVValueString = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CXCAKVAssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAppKeywordValues", x => x.CXCAKVID);
                    table.ForeignKey(
                        name: "FK_CustomerAppKeywordValues_ApplicationKeywords_CXASKID",
                        column: x => x.CXASKID,
                        principalTable: "ApplicationKeywords",
                        principalColumn: "CXAKID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAppKeywordValues_Customers_CXCustomerID",
                        column: x => x.CXCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CXCustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationKeywords_CXASID",
                table: "ApplicationKeywords",
                column: "CXASID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationKeywords_CXKeywordID",
                table: "ApplicationKeywords",
                column: "CXKeywordID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppKeywordScores_CXASKID",
                table: "CustomerAppKeywordScores",
                column: "CXASKID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppKeywordScores_CXCustomerID",
                table: "CustomerAppKeywordScores",
                column: "CXCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppKeywordValues_CXASKID",
                table: "CustomerAppKeywordValues",
                column: "CXASKID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppKeywordValues_CXCustomerID",
                table: "CustomerAppKeywordValues",
                column: "CXCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyEvents_CXASID",
                table: "JourneyEvents",
                column: "CXASID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAppKeywordScores");

            migrationBuilder.DropTable(
                name: "CustomerAppKeywordValues");

            migrationBuilder.DropTable(
                name: "JourneyEvents");

            migrationBuilder.DropTable(
                name: "ApplicationKeywords");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Keywords");
        }
    }
}
