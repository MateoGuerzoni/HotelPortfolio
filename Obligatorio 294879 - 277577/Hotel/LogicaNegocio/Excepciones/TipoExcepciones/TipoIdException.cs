using LogicaNegocio.Excepciones.CabaniaExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoIdException : TipoException
    {
        public TipoIdException() { }
        public TipoIdException(string message) : base(message) { }

    }
}
