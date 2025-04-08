using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVTrackII.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contenidos_AspNetUsers_ApplicationUserId",
                table: "Contenidos");

            migrationBuilder.DropIndex(
                name: "IX_Contenidos_ApplicationUserId",
                table: "Contenidos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contenidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contenidos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contenidos_ApplicationUserId",
                table: "Contenidos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contenidos_AspNetUsers_ApplicationUserId",
                table: "Contenidos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
