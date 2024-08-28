using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{

    public interface IRepositorioTipo : IRepositorio<Tipo>
    {
        public Tipo GetUnTipoByName(String name);
        public IEnumerable<Tipo> GetTipoByName(String name);


    }

}
