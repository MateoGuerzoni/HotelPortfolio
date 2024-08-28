using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.DominioExcepciones;

namespace LogicaNegocio.Excepciones.MantenimientoExcepciones
{
    public class MantenimientoDescripcionException : MantenimientoException
    {
        public MantenimientoDescripcionException() { }
        public MantenimientoDescripcionException(string message) : base(message) { }

    }
}
