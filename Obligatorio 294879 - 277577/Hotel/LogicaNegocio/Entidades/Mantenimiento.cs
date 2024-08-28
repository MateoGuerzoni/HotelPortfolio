using LogicaNegocio.Excepciones;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Mantenimiento : IValidable, IEntity
    {
        [Key]
        public int Id { get; set; }
        public Fecha Fecha { get; set; }
        public Descripcion Descripcion { get; set; }
        public Costo Costo { get; set; }
        public Nombre NombreFuncionario { get; set; }
        public Cabania CabaniaRealizada { get; set; }
        public int CabaniaId { get; set; }
        public void Validar()
        {
        }



    }
}
