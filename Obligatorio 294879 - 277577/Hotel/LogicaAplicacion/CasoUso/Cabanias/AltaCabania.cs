using LogicaAccesoDatos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.CasoUso.Cabanias
{
    public class AltaCabania : IAltaCabania
    {
        private IRepositorioCabania _repo;

        public AltaCabania(IRepositorioCabania repo)
        {
            _repo = repo;
        }

        public void Crear(Cabania cabania)
        {
            try
            {
                _repo.Add(cabania);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CrearMantenimineto(Mantenimiento mantenimiento)
        {
            _repo.AgregarMantenimiento(mantenimiento);
        }

        public int ObtenerNumHabitacion()
        {
            return _repo.ObtenerUltimoNumDeCabania();
        }
    }
}
