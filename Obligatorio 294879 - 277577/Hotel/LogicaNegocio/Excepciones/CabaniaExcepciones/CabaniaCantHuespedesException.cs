using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabaniaExcepciones
{
    public class CabaniaCantHuespedesException : CabaniaException
    {
        public CabaniaCantHuespedesException() { }
        public CabaniaCantHuespedesException(string message) : base(message) { }
    }
}

