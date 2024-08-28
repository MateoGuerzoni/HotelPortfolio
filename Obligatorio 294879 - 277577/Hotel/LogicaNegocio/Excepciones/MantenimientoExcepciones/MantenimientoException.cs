using LogicaNegocio.Excepciones.DominioExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExcepciones
{
    public class MantenimientoException : DomainException
    {
        public MantenimientoException() { }

        public MantenimientoException(string message) : base(message) { }

    }
}
