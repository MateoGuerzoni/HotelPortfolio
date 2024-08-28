using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExcepciones
{
    public class MantenimientoIdException : MantenimientoException
    {
        public MantenimientoIdException() { }
        public MantenimientoIdException(string message) : base(message) { }

    }
}
