using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessBond",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessBond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Cpf = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
                    Cep = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.ResumeId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Url = table.Column<string>(type: "varchar(600)", unicode: false, maxLength: 600, nullable: false),
                    Sector = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySize = table.Column<int>(type: "int", nullable: false),
                    LogoImageUrl = table.Column<string>(type: "varchar(600)", unicode: false, maxLength: 600, nullable: false),
                    Slogan = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: true),
                    Skills = table.Column<long>(type: "bigint", nullable: false),
                    Degrees = table.Column<int>(type: "int", nullable: false),
                    Languages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "ResumeId");
                });

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(1234)", unicode: false, maxLength: 1234, nullable: false),
                    SkillRequired = table.Column<long>(type: "bigint", nullable: false),
                    LanguagesRequired = table.Column<int>(type: "int", nullable: false),
                    DegreesRequired = table.Column<int>(type: "int", nullable: false),
                    AvaibleVacancy = table.Column<int>(type: "int", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcement_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcement_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessBondResume",
                columns: table => new
                {
                    BusinessBondsId = table.Column<int>(type: "int", nullable: false),
                    ResumesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessBondResume", x => new { x.BusinessBondsId, x.ResumesId });
                    table.ForeignKey(
                        name: "FK_BusinessBondResume_BusinessBond_BusinessBondsId",
                        column: x => x.BusinessBondsId,
                        principalTable: "BusinessBond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessBondResume_Resume_ResumesId",
                        column: x => x.ResumesId,
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationResume",
                columns: table => new
                {
                    EducationsId = table.Column<int>(type: "int", nullable: false),
                    ResumesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationResume", x => new { x.EducationsId, x.ResumesId });
                    table.ForeignKey(
                        name: "FK_EducationResume_Education_EducationsId",
                        column: x => x.EducationsId,
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationResume_Resume_ResumesId",
                        column: x => x.ResumesId,
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAnnouncement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered = table.Column<bool>(type: "bit", nullable: false),
                    CandidateResumeId = table.Column<int>(type: "int", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAnnouncement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAnnouncement_Announcement_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateAnnouncement_Candidate_CandidateResumeId",
                        column: x => x.CandidateResumeId,
                        principalTable: "Candidate",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_CompanyId",
                table: "Announcement",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_EducationId",
                table: "Announcement",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessBondResume_ResumesId",
                table: "BusinessBondResume",
                column: "ResumesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnnouncement_AnnouncementId",
                table: "CandidateAnnouncement",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnnouncement_CandidateResumeId",
                table: "CandidateAnnouncement",
                column: "CandidateResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationResume_ResumesId",
                table: "EducationResume",
                column: "ResumesId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_CandidateId",
                table: "Resume",
                column: "CandidateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessBondResume");

            migrationBuilder.DropTable(
                name: "CandidateAnnouncement");

            migrationBuilder.DropTable(
                name: "EducationResume");

            migrationBuilder.DropTable(
                name: "BusinessBond");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Candidate");
        }
    }
}
