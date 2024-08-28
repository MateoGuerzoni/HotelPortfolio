using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.CabaniaExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Vo
{
    public class Nombre
    {
        private string _value;
        public string Value { get { return _value; } set { _value = value; } }
        public Nombre() { }

        public Nombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new CabaniaNombreException("El Nombre no puede ser vacío");
                }
                else
                {
                    if (nombre.Length <= 2)
                    {
                        throw new CabaniaNombreException("El nombre debe ser mayor a 2 caracteres");

                    }
                    else
                    {
                        string pattern = @"^[a-zA-Z\s]+$";
                        Regex regex = new Regex(pattern);
                        if (!(regex.IsMatch(nombre)))
                        {
                            throw new CabaniaNombreException("El nombre solo puede contener letras de la A a la Z, tanto mayúsculas como minúsculas.");
                        }
                    }
                    _value = nombre;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
