using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DF.ACE.Migrations
{
    public partial class ACE_NavigationMenuItem_InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACE_NavigationMenuItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    RequiresAuthentication = table.Column<bool>(nullable: false),
                    RequiredPermissionName = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CustomData = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    ParentNavigationMenuItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACE_NavigationMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACE_NavigationMenuItems_ACE_NavigationMenuItems_ParentNavigationMenuItemId",
                        column: x => x.ParentNavigationMenuItemId,
                        principalTable: "ACE_NavigationMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACE_NavigationMenuItems_ParentNavigationMenuItemId",
                table: "ACE_NavigationMenuItems",
                column: "ParentNavigationMenuItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACE_NavigationMenuItems");
        }
    }
}
