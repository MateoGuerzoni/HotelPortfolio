using LogicaNegocio.Entidades;

namespace WebApi.Dto
{
    public class CabaniaDto
    {
        public int numHabitacion { get; set; }
        public String Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }
        public Boolean Estado { get; set; }
        public int MaxHuespedes { get; set; }
        public int TipoId { get; set; }
        public string Foto { get; set; } = "Sin foto.jpg";

    }
}
