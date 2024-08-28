
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//para manejar token
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.Dto;
using LogicaNegocio.Entidades;

namespace WebApi
{
    public class ManejadorJwt
    {
        /// <summary>
        /// Método para generar el token JWT usando una función estática (no es necesario tener instancias)
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        /// <remarks> Creación del "payload" con tiene la información del usuario que se logueó (subject)
        /// El usuario tiene "claims", que son pares nombre/valor que se utilizan para guardar
        /// en el cliente. No pueden ser sensibles
        /// Se le debe setear el periodo temporal de validez (Expires)
        ///Se utiliza un algoritmo de clave simétrica para generar el token</remarks>

        public static string GenerarToken(Usuario usuarioDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes 

            var clave = Encoding.ASCII.GetBytes(Parametros.PrivateKey);


            //Se incluye un claim para el rol

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuarioDto.Email),
                }),
                Expires = DateTime.UtcNow.AddMonths(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
