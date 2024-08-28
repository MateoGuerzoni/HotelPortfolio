using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.CabaniaExcepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Vo;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioCabania : IRepositorioCabania
    {
        private HotelContext _context;

        public RepositorioCabania(HotelContext context)
        {
            _context = context;
        }


        public void Add(Cabania obj)
        {
            try
            {
                obj.Validar();
                if (GetUnaCabaniaByName(obj.Nombre) == null)
                {
                    //int numHabitacionObt = _altaCabania.ObtenerNumHabitacion();
                    //cabania.numHabitacion = numHabitacionObt + 1;
                    obj.numHabitacion = ObtenerUltimoNumDeCabania() + 1;
                    _context.Cabanias.Add(obj);
                    _context.SaveChanges();
                }
                else
                {
                    throw new CabaniaNombreException("El nombre de cabania ya esta utilizado");
                }
            }
            catch (Exception e)
            {

                throw new CabaniaException("Error al dar de alta cabania "+e.Message);
            }

        }

        public bool Delete(int id)
        {

            Cabania cab = Get(id);
            try
            {
                _context.Cabanias.Remove(cab);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cabania Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new CabaniaIdException("No se recibió el id");
                }
                var Cabania = _context.Cabanias
                    .FirstOrDefault(cabania => cabania.numHabitacion == id);
                if (Cabania == null)
                {
                    throw new CabaniaIdException("No se encontro la cabania");
                }
                return Cabania;
            }
            catch (Exception e)
            {

                throw new CabaniaException("Error al traer la cabania "+e.Message);
            }

        }

        public IEnumerable<Cabania> GetAll()
        {
            var Cabania = _context.Cabanias
                .Include(cabania => cabania.Tipo);


            return Cabania.ToList();

        }

        public void AgregarMantenimiento(Mantenimiento obj)
        {
            try
            {

                int id = obj.CabaniaId;
                Cabania cabania = Get(id);

                Mantenimiento mantenimiento = new Mantenimiento()
                {
                    Fecha = obj.Fecha,
                    Descripcion = obj.Descripcion,
                    Costo = obj.Costo,
                    NombreFuncionario = obj.NombreFuncionario,
                    CabaniaRealizada = cabania

                };
                mantenimiento.Validar();
                _context.Mantenimientos.Add(mantenimiento);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new MantenimientoException("Error al dar de alta mantenimiento"+e.Message);
            }
        }


        public IEnumerable<Mantenimiento> GetMantemientosCabania(Cabania cabania)
        {
            IEnumerable<Mantenimiento> Lista = _context.Mantenimientos
                                .Where(mant => mant.CabaniaRealizada.numHabitacion == cabania.numHabitacion)
                                .ToList();

            return Lista;
        }

        public IEnumerable<Mantenimiento> GetMantemientosFecha(int id, DateTime fecha1, DateTime fecha2)
        {
            IEnumerable<Mantenimiento> Lista = _context.Mantenimientos
                                        .Where(m => m.CabaniaRealizada.numHabitacion == id)
                                        .Where(m => m.Fecha.Value >= fecha1)
                                        .Where(m => m.Fecha.Value <= fecha2)
                                        .Include(m => m.CabaniaRealizada)
                                        .ToList();

            return Lista;
        }

        public IEnumerable<Cabania> GetCabaniaByHuespedes(int huespedes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabania> GetCabaniaByName(string name)
        {
            IEnumerable<Cabania> cabanias = _context.Cabanias.
                                            Where(cabania => cabania.Nombre.Contains(name)).Include(cabania => cabania.Tipo).
                                            ToList();
            return cabanias;
        }

        public Cabania GetUnaCabaniaByName(string name)
        {
            var cabania = _context.Cabanias.Where(cabania => cabania.Nombre.Equals(name)).FirstOrDefault();

            return cabania;
        }


        public IEnumerable<Cabania> GetTipoCabaniaByName(string name)
        {
            IEnumerable<Cabania> cabanias = _context.Cabanias.
                                            Where(cabania => cabania.Tipo.Nombre.Contains(name)).
                                            ToList();
            return cabanias;
        }


        public IEnumerable<Cabania> GetCabaniaByQuantity(int huespedes)
        {
            IEnumerable<Cabania> cabanias = _context.Cabanias.
                                            Where(cabania => cabania.MaxHuespedes >= huespedes).Include(cabania => cabania.Tipo).
                                            ToList();
            return cabanias;
        }


        public IEnumerable<Cabania> GetCabaniaByState(bool estado)
        {
            IEnumerable<Cabania> cabanias = _context.Cabanias.
                                            Where(cabania => cabania.Estado.Equals(estado)).Include(cabania => cabania.Tipo).
                                            ToList();
            return cabanias;
        }

        public IEnumerable<Cabania> GetCabaniaByType(Tipo tipo)
        {

            try
            {
                return _context.Cabanias
                    .Where(Cabania => Cabania.Tipo.Equals(tipo)).Include(cabania => cabania.Tipo).ToList();

            }
            catch (Exception e)
            {

                throw new CabaniaException($"Error en encontrar el tipo de cabania {e.Message}");

            }
        }

        public IEnumerable<Mantenimiento> GetMantenimientosDiarios(Cabania cabania)
        {
            IEnumerable<Mantenimiento> lista = _context.Mantenimientos
                                                .Where(m => m.CabaniaRealizada == cabania)
                                                .Where(m => m.Fecha.Value.Date == DateTime.Today)
                                                 .ToList();
            return lista;
        }

        public int ObtenerUltimoNumDeCabania()
        {
            int numCabania = 0;
            if (_context.Cabanias.Count() > 0)
            {
                numCabania = _context.Cabanias.OrderByDescending(c => c.numHabitacion)
                   .Select(c => c.numHabitacion).FirstOrDefault();
            }
            return numCabania;
        }

        public void Update(Cabania obj)
        {
            throw new NotImplementedException();
        }


        //Dado un monto, obtener el nombre y capacidad(cantidad de huéspedes que puede alojar) de las cabañas que tengan un costo 
        // diario menor a ese monto, que tengan jacuzzi y estén habilitadas para reserva.

        public IEnumerable<Cabania> ObtenerCabaniasConCostoMenor(int monto)
        {
            IEnumerable<Cabania> lista = _context.Cabanias.Where(c => c.Tipo.CostoPorHuesped < monto).
                                        Where(c => c.TieneJacuzzi == true && c.Estado == true).ToList();

            return lista;
        }

        //b.Dados dos valores, obtener los mantenimientos realizados a las cabañas con una capacidad que
        // esté comprendida(topes inclusive) entre ambos valores.
        // El resultado se agrupará por nombre de
        //la persona que realizó el mantenimiento, e incluirá el nombre de la persona y el monto total de
        //los mantenimientos que realizó.

        public IEnumerable<MantenimientoPorPersona> ObtenerMantenimientosPorCapacidad(int min, int max)
        {
            IEnumerable<MantenimientoPorPersona> lista = _context.Mantenimientos
                .Where(m => m.CabaniaRealizada.MaxHuespedes >= min && m.CabaniaRealizada.MaxHuespedes <= max)
                .GroupBy(m => m.NombreFuncionario.Value)
                .Select(g => new MantenimientoPorPersona
                {
                    NombrePersona = g.Key,
                    MontoTotal = g.Sum(m => m.Costo.Value)
                })
                .ToList();

            return lista;
        }


    }
}
