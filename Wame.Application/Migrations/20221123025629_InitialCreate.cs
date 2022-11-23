using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wame.Application.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseIdentities",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aptitudes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2022, 11, 23, 2, 56, 29, 431, DateTimeKind.Utc).AddTicks(6325))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseIdentities", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecruiterEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_BaseIdentities_RecruiterEmail",
                        column: x => x.RecruiterEmail,
                        principalTable: "BaseIdentities",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Campaigns_Jobs_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecruiterEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    General = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aptitudes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strengths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_BaseIdentities_CandidateEmail",
                        column: x => x.CandidateEmail,
                        principalTable: "BaseIdentities",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Interviews_BaseIdentities_RecruiterEmail",
                        column: x => x.RecruiterEmail,
                        principalTable: "BaseIdentities",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Interviews_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_CampaignId",
                table: "BaseIdentities",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_PositionId",
                table: "Campaigns",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_RecruiterEmail",
                table: "Campaigns",
                column: "RecruiterEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CampaignId",
                table: "Interviews",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CandidateEmail",
                table: "Interviews",
                column: "CandidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruiterEmail",
                table: "Interviews",
                column: "RecruiterEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Campaigns_CampaignId",
                table: "BaseIdentities",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Campaigns_CampaignId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
