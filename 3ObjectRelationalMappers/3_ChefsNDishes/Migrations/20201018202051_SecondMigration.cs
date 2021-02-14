using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chefs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "Chefs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Chefs",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Chefs",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Chefs");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Chefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chefs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
