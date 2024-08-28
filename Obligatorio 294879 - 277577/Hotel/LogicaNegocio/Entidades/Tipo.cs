using LogicaNegocio.IntefacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Diagnostics;
using LogicaNegocio.Excepciones.TipoExcepciones;

namespace LogicaNegocio.Entidades
{
    public class Tipo : IValidable, IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double CostoPorHuesped { get; set; }



        public void Validar()
        {
            ValidarNombreABC();
            ValidarDscTipo();
            ValidarCostoPorHuesped();

        }


        private void ValidarNombreABC()
        {
            try
            {
                if (Nombre == null || Nombre == " ")
                {
                    throw new TipoNombreException("El nombre no puede ser vacio");

                }
                else
                {
                    if (Nombre.Trim() != Nombre)
                    {
                        throw new TipoNombreException("El nombre no puede tener espacios al principio y/o al final.");

                    }
                    string pattern = @"^[a-zA-Z\s]+$";
                    Regex regex = new Regex(pattern);
                    if (!(regex.IsMatch(Nombre)))
                    {
                        throw new TipoNombreException("El nombre solo puede contener letras de la A a la Z, tanto mayúsculas como minúsculas.");

                    }
                }
            }
            catch (TipoNombreException)
            {
                throw;
            }

        }



        private void ValidarDscTipo()
        {
            try
            {
                if (Descripcion.Length < 10 || Descripcion.Length > 200)
                {
                    throw new TipoDescripcionException("La descripcion debe tener minimo 10 caracteres o maximo 200");
                }
            }
            catch (TipoDescripcionException)
            {
                throw;
            }

        }

        private void ValidarCostoPorHuesped()
        {
            if (CostoPorHuesped <= 0)
            {
                throw new TipoCostoException("El costo por huesped no puede ser 0 o negativo");
            }
        }
    }
}




