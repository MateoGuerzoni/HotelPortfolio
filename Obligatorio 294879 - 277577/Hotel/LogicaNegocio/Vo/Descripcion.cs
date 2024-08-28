using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Vo
{
    public class Descripcion
    {
        private string _value;
        public string Value { get { return _value; } set { _value = value; } }
        public Descripcion() { }
        public Descripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                throw new MantenimientoDescripcionException("La descripcion no puede ser vacia");
            }
            if (Parametros.min > descripcion.Length || Parametros.max < descripcion.Length)
            {
                throw new MantenimientoDescripcionException($"La descripcion no puede ser menor de {Parametros.min} caracteres o mayor a {Parametros.max}");
            }
            _value = descripcion;
        }
    }
}
