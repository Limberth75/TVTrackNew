using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVTrackII.Migrations
{
    /// <inheritdoc />
    public partial class CreateContenidosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Contenidos");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Contenidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Contenidos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DuracionMinutos",
                table: "Contenidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEstreno",
                table: "Contenidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuracionMinutos",
                table: "Contenidos");

            migrationBuilder.DropColumn(
                name: "FechaEstreno",
                table: "Contenidos");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Contenidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Contenidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<double>(
                name: "Calificacion",
                table: "Contenidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
