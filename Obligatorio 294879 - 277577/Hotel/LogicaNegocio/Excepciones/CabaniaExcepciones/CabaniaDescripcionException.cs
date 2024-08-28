using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabaniaExcepciones
{
    public class CabaniaDescripcionException : CabaniaException
    {
        public CabaniaDescripcionException() { }
        public CabaniaDescripcionException(string message) : base(message) { }
    }
}
