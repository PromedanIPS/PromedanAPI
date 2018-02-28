using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PromedanAPI.BD;
using Newtonsoft.Json;
using System.Data;
using System.Web.Http.Cors;
using System.Security.Cryptography;

namespace PromedanAPI.Controllers
{
    
    public class EmpleadosController : ApiController
    {
        AccesoDatos objDatos = new AccesoDatos();
        // GET: api/Empleados
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Empleados/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empleados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empleados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empleados/5
        public void Delete(int id)
        {
        }


        /// <summary>
        /// devuelve encriptada la contraseña
        /// </summary>
        /// <param name="laCadena"></param>
        /// <returns></returns>
        public static string encriptar(string laCadena)
        {
            SHA1CryptoServiceProvider elProveedor = new SHA1CryptoServiceProvider();
            byte[] vectoBytes = System.Text.Encoding.UTF8.GetBytes(laCadena);
            byte[] inArray = elProveedor.ComputeHash(vectoBytes);
            elProveedor.Clear();
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TipoId"></param>
        /// <param name="Cedula"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Telefono"></param>
        /// <param name="Celular"></param>
        /// <param name="FechaNacimiento"></param>
        /// <param name="LugarNacimiento"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="Sexo"></param>
        /// <param name="NumeroHijo"></param>
        /// <param name="CabezaFamilia"></param>
        /// <param name="RH"></param>
        /// <param name="Direccion"></param>
        /// <param name="email"></param>
        /// <param name="EmailPersonal"></param>
        /// <param name="Sede"></param>
        /// <param name="IdNivelEducativo"></param>
        /// <param name="InstitucionEgresado"></param>
        /// <param name="RegistroMedico"></param>
        /// <param name="Profesion"></param>
        /// <param name="Usuario"></param>
        /// <param name="Clave"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        public string Get(string TipoId, string Cedula, string Nombre, string Apellido, string Telefono, string Celular, string FechaNacimiento, string LugarNacimiento, string EstadoCivil, string Sexo, string NumeroHijo, string CabezaFamilia, string RH, string Direccion, string email, string EmailPersonal, string Sede, string IdNivelEducativo, string InstitucionEgresado, string RegistroMedico, string Profesion,string Usuario, string Clave, string Token)
        {
            if (Token == "juhudyundyhdytdrkiui")
            {
               Clave = encriptar(Clave).ToString().Substring(0, 20);
                FechaNacimiento = FechaNacimiento.Substring(0, 4) + FechaNacimiento.Substring(5, 2) + FechaNacimiento.Substring(8, 2);
                string sql = "spTalentoHumano_ActualizarDatos_Empleados '" + TipoId + "','" + Cedula + "','" + Nombre + "','" + Apellido + "','" + Telefono + "','" + Celular + "','" + FechaNacimiento + "','" + LugarNacimiento + "','" + EstadoCivil + "','" + Sexo + "','" + NumeroHijo + "','" + CabezaFamilia + "','" + RH + "','" + Direccion + "','" + email + "','" + EmailPersonal + "','" + Sede + "','" + IdNivelEducativo + "','" + InstitucionEgresado + "','" + RegistroMedico + "','" + Profesion + "','" + Usuario + "','" + Clave + "'";
               objDatos.ejecutarSentencia(sql);
                return "OK";
            }
            return null;
        }
    }
}

