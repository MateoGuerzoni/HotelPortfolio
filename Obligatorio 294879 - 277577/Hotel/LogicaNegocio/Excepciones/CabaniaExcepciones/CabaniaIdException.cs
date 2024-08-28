using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabaniaExcepciones
{
    public class CabaniaIdException : CabaniaException
    {
        public CabaniaIdException() { }
        public CabaniaIdException(string message) : base(message) { }

    }
}
