using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppCliente.Models
{
    public class VMMantenimiento
    {
        //public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string NombreFuncionario { get; set; }
        public int CabaniaId { get; set; }
    }
}
