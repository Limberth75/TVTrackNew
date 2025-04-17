using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVTrackII.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechaHistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaVisualizacion",
                table: "HistorialVisualizacion",
                newName: "Fecha");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "HistorialVisualizacion",
                newName: "FechaVisualizacion");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }
    }
}
