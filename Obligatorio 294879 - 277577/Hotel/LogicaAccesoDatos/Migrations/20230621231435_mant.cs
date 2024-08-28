using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class mant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabanias_CabaniaRealizadanumHabitacion",
                table: "Mantenimientos");

            migrationBuilder.RenameColumn(
                name: "CabaniaRealizadanumHabitacion",
                table: "Mantenimientos",
                newName: "CabaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimientos_CabaniaRealizadanumHabitacion",
                table: "Mantenimientos",
                newName: "IX_Mantenimientos_CabaniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabanias_CabaniaId",
                table: "Mantenimientos",
                column: "CabaniaId",
                principalTable: "Cabanias",
                principalColumn: "numHabitacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabanias_CabaniaId",
                table: "Mantenimientos");

            migrationBuilder.RenameColumn(
                name: "CabaniaId",
                table: "Mantenimientos",
                newName: "CabaniaRealizadanumHabitacion");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimientos_CabaniaId",
                table: "Mantenimientos",
                newName: "IX_Mantenimientos_CabaniaRealizadanumHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabanias_CabaniaRealizadanumHabitacion",
                table: "Mantenimientos",
                column: "CabaniaRealizadanumHabitacion",
                principalTable: "Cabanias",
                principalColumn: "numHabitacion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
