using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.DominioExcepciones;

namespace LogicaNegocio.Excepciones.CabaniaExcepciones
{
    public class CabaniaNombreException : CabaniaException
    {
        public CabaniaNombreException() { }
        public CabaniaNombreException(string message) : base(message) { }

    }
}
