using LogicaNegocio.Excepciones;
using LogicaNegocio.IntefacesDominio;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.CabaniaExcepciones;

namespace LogicaNegocio.Entidades
{
    public class Cabania : IValidable, IEntity
    {
        [Key]
        public int numHabitacion { get; set; }

        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }
        public String Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }

        public Boolean Estado { get; set; }

        public int MaxHuespedes { get; set; }
        public String Foto { get; set; }




        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarCantHuespedes();
        }



        private void ValidarNombre()
        {

            try
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    throw new CabaniaNombreException("El Nombre no puede ser vacío");
                }
                else
                {
                    if (Nombre.Length <= 2)
                    {
                        throw new CabaniaNombreException("El nombre debe ser mayor a 2 caracteres");

                    }
                    else
                    {
                        string pattern = @"^[a-zA-Z\s]+$";
                        Regex regex = new Regex(pattern);
                        if (!(regex.IsMatch(Nombre)))
                        {
                            throw new CabaniaNombreException("El nombre solo puede contener letras de la A a la Z, tanto mayúsculas como minúsculas.");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new CabaniaDescripcionException("La descripcion no puede ser vacia");
            }
            if (Parametros.min < 10 || Parametros.max > 500)
            {
                throw new CabaniaDescripcionException("La descripcion no puede ser menor de 10 caracteres o mayor a 500");
            }
        }

        public void ValidarCantHuespedes()
        {
            if (MaxHuespedes <= 0)
            {
                throw new CabaniaCantHuespedesException("El numero de huespedes debe ser mayr a 0");
            }
        }
    }
}
