using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        //public Usuario Login(string email, string password);

        public IEnumerable<Usuario> GetUsuariosByName(string name);

        public Usuario GetUsuarioByMail(string email);

        public void precargarUsuarios();

        public bool ChequearContraseniaPorUsuario(string email, string pass);

    }
}
