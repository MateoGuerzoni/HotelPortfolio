using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExcepciones
{
    public class MantenimientoFechaException : MantenimientoException
    {
        public MantenimientoFechaException() { }

        public MantenimientoFechaException(string message) : base(message) { }
    }
}
