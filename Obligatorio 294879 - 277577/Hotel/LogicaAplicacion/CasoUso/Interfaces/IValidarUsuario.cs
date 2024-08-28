using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Interfaces
{
    public interface IValidarUsuario
    {
        public bool ValidarEmailContrasenia(string email, string pass);

    }
}
