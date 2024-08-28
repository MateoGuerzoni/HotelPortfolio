using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;

namespace LogicaNegocio.Vo
{
    public class Costo
    {
        private double _value;
        public double Value { get { return _value; } set { _value = value; } }
        public Costo() { }
        public Costo(double costo) 
        {
            try
            {
                if (costo == null)
                {
                    throw new MantenimientoCostoException("El costo no puede ser vacío");
                }
                if (costo <= 0)
                {
                    throw new MantenimientoCostoException("El costo no puede ser menor que 1");
                }
                _value = costo;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
