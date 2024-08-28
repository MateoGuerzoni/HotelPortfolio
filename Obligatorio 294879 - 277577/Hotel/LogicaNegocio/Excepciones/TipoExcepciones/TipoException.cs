using LogicaNegocio.Excepciones.DominioExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoException : DomainException
    {
        public TipoException() { }

        public TipoException(string message) : base(message) { }

    }
}
