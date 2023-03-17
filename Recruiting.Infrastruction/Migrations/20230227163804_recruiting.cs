using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastruction.Migrations
{
    /// <inheritdoc />
    public partial class recruiting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    EmailId = table.Column<string>(type: "varchar(70)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    NumberOfPositions = table.Column<int>(type: "int", nullable: false),
                    HiringManagerId = table.Column<int>(type: "int", nullable: false),
                    HiringManagerName = table.Column<string>(type: "varchar(30)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedReason = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobCategory = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionStatusId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    JobRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submission_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submission_JobRequirement_JobRequirementId",
                        column: x => x.JobRequirementId,
                        principalTable: "JobRequirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submission_SubmissionStatus_SubmissionStatusId",
                        column: x => x.SubmissionStatusId,
                        principalTable: "SubmissionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submission_CandidateId",
                table: "Submission",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_JobRequirementId",
                table: "Submission",
                column: "JobRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionStatusId",
                table: "Submission",
                column: "SubmissionStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "JobRequirement");

            migrationBuilder.DropTable(
                name: "SubmissionStatus");
        }
    }
}
