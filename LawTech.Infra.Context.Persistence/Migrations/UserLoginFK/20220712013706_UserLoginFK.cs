using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawTech.Infra.Context.Persistence.Migrations.UserLoginFK
{
    public partial class UserLoginFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserLogin",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "UserLogin",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserLogin",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserLogin");
        }
    }
}
