using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.DominioExcepciones;

namespace LogicaNegocio.Excepciones.UsuarioExcepciones
{
    public class UsuarioContraseniaException : DomainException
    {
        public UsuarioContraseniaException() { }
        public UsuarioContraseniaException(string message) : base(message) { }
    }
}
