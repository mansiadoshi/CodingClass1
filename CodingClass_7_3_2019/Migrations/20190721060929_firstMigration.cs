using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingClass_7_3_2019.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAccounts",
                columns: table => new
                {
                    StudentAccountNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentFirstName = table.Column<string>(nullable: true),
                    StudentLastName = table.Column<string>(nullable: true),
                    StudentDateOfBirth = table.Column<string>(nullable: true),
                    StudentEmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    StudentDifficultyLevel = table.Column<int>(nullable: false),
                    StudentClassType = table.Column<int>(nullable: false),
                    TotalClassesEnrolled = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    AmountDue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumber", x => x.StudentAccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "StudentHistory",
                columns: table => new
                {
                    CourseHistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    ClassesEnrolledFor = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<int>(nullable: false),
                    PaymentMadeDateAndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseHistoryID", x => x.CourseHistoryID);
                    table.ForeignKey(
                        name: "FK_StudentHistory_StudentAccounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "StudentAccounts",
                        principalColumn: "StudentAccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentHistory_AccountNumber",
                table: "StudentHistory",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHistory");

            migrationBuilder.DropTable(
                name: "StudentAccounts");
        }
    }
}
