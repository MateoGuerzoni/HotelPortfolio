using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Interfaces
{
    public interface IBuscarUsuario
    {
        public Usuario BuscarPorMail(string email);
        IEnumerable<Usuario> BuscarTodos();
    }
}
