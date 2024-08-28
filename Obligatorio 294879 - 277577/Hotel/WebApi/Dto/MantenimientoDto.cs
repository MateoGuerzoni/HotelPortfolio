using LogicaNegocio.Entidades;
using LogicaNegocio.Vo;

namespace WebApi.Dto
{
    public class MantenimientoDto
    {
        public DateTime Fecha   { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string NombreFuncionario { get; set; }
        public int CabaniaID { get; set; }

    }
}
