using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wame.Application.Migrations
{
    public partial class CreatedInvitationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvitationId",
                table: "Campaigns",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitationId",
                table: "Campaigns");
        }
    }
}
