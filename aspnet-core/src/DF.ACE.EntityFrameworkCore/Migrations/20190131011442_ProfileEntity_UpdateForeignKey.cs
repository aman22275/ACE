using Microsoft.EntityFrameworkCore.Migrations;

namespace DF.ACE.Migrations
{
    public partial class ProfileEntity_UpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ProfileAttachment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileAttachment_UserId",
                table: "ProfileAttachment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAttachment_AbpUsers_UserId",
                table: "ProfileAttachment",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAttachment_AbpUsers_UserId",
                table: "ProfileAttachment");

            migrationBuilder.DropIndex(
                name: "IX_ProfileAttachment_UserId",
                table: "ProfileAttachment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileAttachment");
        }
    }
}
