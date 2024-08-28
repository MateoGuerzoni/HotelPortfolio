using LogicaNegocio.Vo;

namespace WebApi.Dto
{
    public class TipoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double CostoPorHuesped { get; set; }
    }
}
