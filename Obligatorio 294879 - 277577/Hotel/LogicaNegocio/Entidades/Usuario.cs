using LogicaNegocio.Excepciones.UsuarioExcepciones;
using LogicaNegocio.IntefacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IValidable, IEntity
    {

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }



        public void Validar()
        {
            ValidarEmail();
            ValidarContrasenia();

        }


        //Validacion de Linq
        private void ValidarContrasenia()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    bool tieneMayusculas = Password.Any(c => char.IsUpper(c));
                    bool tieneMinusculas = Password.Any(c => char.IsLower(c));
                    bool tieneNumeros = Password.Any(c => char.IsDigit(c));

                    if (!(Password.Length >= 6 && tieneMayusculas && tieneMinusculas && tieneNumeros))
                    {
                        throw new UsuarioContraseniaException("La contraseña debe tener al menos 6 caracteres y contener al menos una letra mayúscula, una letra minúscula y un número.");
                    }
                }
                else
                {
                    throw new UsuarioContraseniaException("La contraseña no puede ser vacia");
                }
            }
            catch (UsuarioContraseniaException ex)
            {
                throw ex;

            }


        }



        //Validacion de C#
        private void ValidarEmail()
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    if (addr.Address != Email)
                    {
                        throw new UsuarioEmailException("El correo electrónico no es válido.");
                    }
                }
                else
                {
                    throw new UsuarioEmailException("El correo electrónico no puede ser nulo o vacío.");
                }
            }
            catch (UsuarioEmailException ex)
            {
                throw ex;

            }
        }

    }
}

