using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.CasoUso.Tipos
{
    public class AltaTipo : IAltaTipo
    {
        private IRepositorioTipo _repo;

        public AltaTipo(IRepositorioTipo repo)
        {
            _repo = repo;
        }

        public void Crear(Tipo tipo)
        {
            try
            {
                _repo.Add(tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

