using LogicaNegocio.Entidades;

namespace WebApp.Models
{
    public class ViewModelCabania
    {

        public int numHabitacion { get; set; }

        public Tipo Tipo { get; set; }
        public String Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }

        public Boolean Estado { get; set; }

        public int MaxHuespedes { get; set; }
        public String Foto { get; set; }

        public IFormFile Imagen { get; set; }

    }
}
