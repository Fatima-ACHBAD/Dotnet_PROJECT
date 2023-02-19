using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mini1projet2.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Produit");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Produit",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Produit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Produit");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Produit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Produit",
                type: "datetime2",
                nullable: true);
        }
    }
}
