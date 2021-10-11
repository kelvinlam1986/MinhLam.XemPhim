using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhLam.XemPhim.Web.Migrations
{
    public partial class AddUserTypeToAccountGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AccountGroups",
                type: "int",
                nullable: false,
                defaultValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AccountGroups");
        }
    }
}
