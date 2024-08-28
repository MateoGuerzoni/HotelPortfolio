using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.InterfacesRepositorio;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioTipo : IRepositorioTipo
    {
        private HotelContext _context;

        public RepositorioTipo(HotelContext context)
        {
            _context = context;
        }

        public void Add(Tipo obj)
        {
            try
            {
                if (NombreUsado(obj) == false)
                {
                    obj.Validar();
                    _context.Tipos.Add(obj);
                    _context.SaveChanges();
                }
                else
                {

                    throw new TipoNombreException("Nombre ya usado");
                }

            }
            catch (Exception e)
            {

                throw new TipoException("Error a dar de alta el tipo " + e.Message);
            }

        }
        public bool NombreUsado(Tipo tipo)
        {
            IEnumerable<Tipo> tipos = _context.Tipos.Where(t => t.Nombre.Equals(tipo.Nombre));
            if (tipos.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                if (!ValidarSiUsado(id))
                {
                    Tipo tipo = Get(id);
                    _context.Tipos.Remove(tipo);
                    _context.SaveChanges();
                    return true;
                }
                throw new TipoException("Ya esta siendo usado, no se puede borrar");

            }
            catch (Exception e)
            {
                throw new TipoException("Error a borrar el tipo "+e.Message);
            }
        }

        public bool ValidarSiUsado(int id)
        {
            Tipo tipo = Get(id);
            IEnumerable<Cabania> listaCabanias = _context.Cabanias.Where(c => c.Tipo == tipo).ToList();
            return listaCabanias.Count() > 0 ? true : false;
        }

        public Tipo Get(int id)
        {
            if (id == 0)
            {
                throw new TipoIdException("No se recibió el id");
            }
            var tipo = _context.Tipos
                .FirstOrDefault(tipo => tipo.Id == id);
            if (tipo == null)
            {
                throw new TipoIdException("No se encontro el id");
            }
            return tipo;

        }

        public IEnumerable<Tipo> GetAll()
        {
            return _context.Tipos.ToList();
        }

        public IEnumerable<Tipo> GetTipoByName(String name)
        {

            var tipos = _context.Tipos.Where(t => t.Nombre.Contains(name)).ToList();

            return tipos;

        }

        public Tipo GetUnTipoByName(String name)
        {
            var tipos = _context.Tipos.Where(t => t.Nombre.Equals(name)).FirstOrDefault();
            return tipos;
        }



        public void Update(Tipo obj)
        {
            try
            {
                obj.Validar();
                _context.Tipos.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new TipoException("Error al modificar "+e.Message);
            }


        }
    }
}
