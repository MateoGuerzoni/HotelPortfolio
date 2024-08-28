using LogicaNegocio.Excepciones.DominioExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoCostoException : TipoException
    {
        public TipoCostoException() { }
        public TipoCostoException(string message) : base(message) { }
    }
}
