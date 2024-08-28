using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {
        private HotelContext _context;

        public RepositorioMantenimiento(HotelContext context)
        {
            _context = context;
        }

        public void Add(Mantenimiento obj)
        {
            try
            {
                obj.Validar();
                _context.Mantenimientos.Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex) {
                throw new MantenimientoException("Error al dar de alta"+ex.Message);
            }
            
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mantenimiento Get(int id)
        {
            var Mantenimiento = _context.Mantenimientos
                            .FirstOrDefault(mant => mant.Id == id);
            if (Mantenimiento == null)
            {
                throw new MantenimientoIdException("No se encontro el id");
            }
            return Mantenimiento;

        }


        public IEnumerable<Mantenimiento> GetAll()
        {
            throw new NotImplementedException();
        }



        public void Update(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}