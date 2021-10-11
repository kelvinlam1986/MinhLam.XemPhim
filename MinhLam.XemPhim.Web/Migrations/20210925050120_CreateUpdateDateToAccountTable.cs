using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhLam.XemPhim.Web.Migrations
{
    public partial class CreateUpdateDateToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedData",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedData",
                table: "Accounts");
        }
    }
}
