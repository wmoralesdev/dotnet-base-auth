using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Responsibilities = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseIdentities",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<string>(type: "text", nullable: true),
                    Formation = table.Column<string>(type: "text", nullable: true),
                    Aptitudes = table.Column<string>(type: "text", nullable: true),
                    CampaignId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseIdentities", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecruiterEmail = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    HiredEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_BaseIdentities_HiredEmail",
                        column: x => x.HiredEmail,
                        principalTable: "BaseIdentities",
                        principalColumn: "Email");
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

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_CampaignId",
                table: "BaseIdentities",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_HiredEmail",
                table: "Campaigns",
                column: "HiredEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_PositionId",
                table: "Campaigns",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_RecruiterEmail",
                table: "Campaigns",
                column: "RecruiterEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Campaigns_CampaignId",
                table: "BaseIdentities",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Campaigns_CampaignId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
