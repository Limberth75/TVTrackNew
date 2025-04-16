using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVTrackII.Migrations
{
    /// <inheritdoc />
    public partial class AddHistorialFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Contenidos_ContenidoId",
                table: "Historiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Usuarios_UsuarioId",
                table: "Historiales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Historiales",
                table: "Historiales");

            migrationBuilder.RenameTable(
                name: "Historiales",
                newName: "HistorialVisualizacion");

            migrationBuilder.RenameIndex(
                name: "IX_Historiales_UsuarioId",
                table: "HistorialVisualizacion",
                newName: "IX_HistorialVisualizacion_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Historiales_ContenidoId",
                table: "HistorialVisualizacion",
                newName: "IX_HistorialVisualizacion_ContenidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialVisualizacion",
                table: "HistorialVisualizacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialVisualizacion_Contenidos_ContenidoId",
                table: "HistorialVisualizacion",
                column: "ContenidoId",
                principalTable: "Contenidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialVisualizacion_Usuarios_UsuarioId",
                table: "HistorialVisualizacion",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialVisualizacion_Contenidos_ContenidoId",
                table: "HistorialVisualizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialVisualizacion_Usuarios_UsuarioId",
                table: "HistorialVisualizacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialVisualizacion",
                table: "HistorialVisualizacion");

            migrationBuilder.RenameTable(
                name: "HistorialVisualizacion",
                newName: "Historiales");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialVisualizacion_UsuarioId",
                table: "Historiales",
                newName: "IX_Historiales_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialVisualizacion_ContenidoId",
                table: "Historiales",
                newName: "IX_Historiales_ContenidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Historiales",
                table: "Historiales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Contenidos_ContenidoId",
                table: "Historiales",
                column: "ContenidoId",
                principalTable: "Contenidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Usuarios_UsuarioId",
                table: "Historiales",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
