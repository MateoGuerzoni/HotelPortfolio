using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PKIDTIPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanias_Tipos_TipoNombre",
                table: "Cabanias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Cabanias_TipoNombre",
                table: "Cabanias");

            migrationBuilder.DropColumn(
                name: "TipoNombre",
                table: "Cabanias");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tipos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Cabanias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_TipoId",
                table: "Cabanias",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Cabanias_TipoId",
                table: "Cabanias");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Cabanias");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Tipos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TipoNombre",
                table: "Cabanias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_TipoNombre",
                table: "Cabanias",
                column: "TipoNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanias_Tipos_TipoNombre",
                table: "Cabanias",
                column: "TipoNombre",
                principalTable: "Tipos",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
