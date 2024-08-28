using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Vo
{
    public class Fecha
    {
        private DateTime _value;
        public DateTime Value { get { return _value; } set { _value = value; } }
        public Fecha() { }
    
        public Fecha(DateTime fecha ) {
            try
            {
                if(fecha == null){
                    throw new MantenimientoFechaException("La fecha no puede ser vacía");
                }
                if (fecha > DateTime.Now)
                {
                    throw new MantenimientoFechaException("La fecha no es valida");
                }
                _value = fecha;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
