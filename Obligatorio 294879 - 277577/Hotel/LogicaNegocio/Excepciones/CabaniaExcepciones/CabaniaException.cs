using LogicaNegocio.Excepciones.DominioExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabaniaExcepciones
{
    public class CabaniaException : DomainException
    {
        public CabaniaException() { }

        public CabaniaException(string message) : base(message) { }

    }
}
