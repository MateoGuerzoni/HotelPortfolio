using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Interfaces
{
    public interface IListarTipo
    {
        public IEnumerable<Tipo> ListarTodo();
        public IEnumerable<Tipo> ListarTipoPorNombre(string nombre);
        public Tipo ListarUnTipoPorNombre(string nombre);
        public Tipo ListarUno(int id);

    }
}
