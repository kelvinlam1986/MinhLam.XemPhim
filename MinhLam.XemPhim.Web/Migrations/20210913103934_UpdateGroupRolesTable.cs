using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhLam.XemPhim.Web.Migrations
{
    public partial class UpdateGroupRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoles_Roles_RoleId",
                table: "GroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoles_RoleId",
                table: "GroupRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "GroupRoles");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "GroupRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "GroupRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "GroupRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_RoleId",
                table: "GroupRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoles_Roles_RoleId",
                table: "GroupRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
