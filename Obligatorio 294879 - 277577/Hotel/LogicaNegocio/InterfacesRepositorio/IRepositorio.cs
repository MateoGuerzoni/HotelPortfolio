using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        public void Add(T obj);
        public void Update(T obj);
        public bool Delete(int id);
        public T Get(int id);
        public IEnumerable<T> GetAll();

    }
}
