using LogicaNegocio.Entidades;
using LogicaNegocio.Vo;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class precarga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Usuarios", new[] { "Id", "Email", "Password" }, new object[] { 1, "diego@ort.com", "diego123" });
            migrationBuilder.InsertData("Usuarios", new[] { "Id", "Email", "Password" }, new object[] { 2, "mateo@ort.com", "mateo123" });

            migrationBuilder.InsertData("Tipos", new[] { "Id", "Nombre", "Descripcion", "CostoPorHuesped" }, new object[] { 1, "Deluxe", "Cabanias mas costosas", 200 });
            migrationBuilder.InsertData("Tipos", new[] { "Id", "Nombre", "Descripcion", "CostoPorHuesped" }, new object[] { 2, "Clasica", "Cabanias clasicas", 150 });
            migrationBuilder.InsertData("Tipos", new[] { "Id", "Nombre", "Descripcion", "CostoPorHuesped" }, new object[] { 3, "Economica", "Cabanias mas economicas", 50 });
            migrationBuilder.InsertData("Tipos", new[] { "Id", "Nombre", "Descripcion", "CostoPorHuesped" }, new object[] { 4, "Renovada", "Cabanias hechas a nuevas", 120 });

            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 1, "Cabania extra deluxe ", "Cabania de muy alta gama 1", true, true, 8, "foto1", 1 });
            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 2, "Cabania deluxe ", "Cabania alta gama ", true, true, 6, "foto1", 1 });
            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 3, "Cabania clasica ", "Cabania clasica ", false, false, 5, "foto1", 2 });
            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 4, "Cabania eco ", "Cabania economica pero bonita", true, false, 2, "foto1", 3 });
            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 5, "Cabania super eco ", "Cabania economica extrema", false, false, 2, "foto1", 3 });
            migrationBuilder.InsertData("Cabanias", new[] { "numHabitacion", "Nombre", "Descripcion", "TieneJacuzzi", "Estado", "MaxHuespedes", "Foto", "TipoId" }, new object[] { 6, "Cabania clase media ", "Cabania intermedia", true, true, 5, "foto1", 2 });



            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 1, DateTime.UtcNow, "Reparacion de tuberias", 500, "Messi", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 2, DateTime.UtcNow, "Reparacion de puertas", 200, "Messi", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 3, DateTime.UtcNow, "Reparacion de electricidad", 500, "Messi", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 4, DateTime.UtcNow.AddDays(-5), "Reparacion de techo", 800, "Messi", 2 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 5, DateTime.UtcNow.AddDays(-5), "Reparacion de electricidad", 200, "Messi", 2 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 6, DateTime.UtcNow.AddDays(-5), "Reparacion de pisos", 300, "Messi", 3 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 7, DateTime.UtcNow.AddDays(-10), "Reparacion de pisos", 300, "Don Ramon", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 8, DateTime.UtcNow.AddDays(-10), "Reparacion de techo", 340, "Don Ramon", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 9, DateTime.UtcNow.AddDays(-15), "Reparacion de electricdad", 400, "Zombo", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 10, DateTime.UtcNow.AddDays(-15), "Reparacion de mesas", 300, "Zombo", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 11, DateTime.UtcNow.AddDays(-20), "Reparacion de sillas", 340, "Zombo", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 12, DateTime.UtcNow.AddDays(-25), "Reparacion de internet", 400, "Zombo", 4 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 13, DateTime.UtcNow.AddDays(-25), "Reparacion de tuberias", 500, "Ibra", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 14, DateTime.UtcNow.AddDays(-25), "Reparacion de puertas", 200, "Ibra", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 15, DateTime.UtcNow.AddDays(-30), "Reparacion de tuberias", 500, "Ibra", 1 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 16, DateTime.UtcNow.AddDays(-30), "Reparacion de tuberias", 700, "Forlan", 5 });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Id", "Fecha", "Descripcion", "Costo", "NombreFuncionario", "CabaniaRealizadanumHabitacion" }, new object[] { 17, DateTime.UtcNow.AddDays(-30), "Reparacion de puertas", 400, "Forlan", 6 });
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DeleteData("Temas", new[] { "Nombre" }, new[] { "Tema2" });
        //}
    }
}
