using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.DominioExcepciones;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoDescripcionException : TipoException
    {
        public TipoDescripcionException() { }
        public TipoDescripcionException(string message) : base(message) { }
    }
}
