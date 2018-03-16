using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PromedanAPI.BD;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;

namespace PromedanAPI.Controllers
{
    public class LoginController : ApiController
    {
        
        AccesoDatos objDatos = new AccesoDatos();
        // GET: api/Login
        public DataTable Get()
        {

            var dt = objDatos.llenarDataSet("Select IdCentrocosto As Id,Descripcion,Telefono From centrocostos").Tables[0];
            //return JsonConvert.SerializeObject(data);

            return dt;

            //new string[] { "jaimegg", "apiiii" };
        }

        // GET: api/Login/5
        //public string validarUsuario()
        //{
        //    //return JsonConvert.SerializeObject(objDatos.ejecutarSentencia("select * from centroatencion"));
        //}

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value ebntro  gest";
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
            string a = "entro";
        }

        public class ApiResponse
        {
            public string Activo { get; set; }
            //public string message { get; set; }
        }

        /// <summary>
        /// Permite Loguearse Evolution
        /// </summary>
        /// <param name="usuario">Usuario Evolution</param>
        /// <param name="pwd">Contraseña Evoluion</param>
        /// <param name="permisos">Token entregado</param>
        /// <returns>Acceso al sistema</returns>        
        public DataTable Get(string Email, string Contraseña,string Token)
        {
            
            if (Token == "jklminu")
            {
                var dt = objDatos.llenarDataSet("spMovil_ValidarUsuario" + "'" + Email + "','" + Contraseña + "'").Tables[0];
                return dt;
            }
            return null;

        }

        /// <summary>
        /// Permite Loguearse Evolution
        /// </summary>
        /// <param name="Usuario">Usuario Evolution</param>
        /// <param name="Pass">Contraseña Evoluion</param>
        /// <param name="Token">Token entregado</param>
        /// <returns>Acceso al sistema</returns>        
        public DataTable validarUsuarioEmpleado(string Usuario, string Pass, string Token)
        {
            Pass = encriptar(Pass).ToString().Substring(0, 20);
            if (Token == "jklminu")
            {
                var dt = objDatos.llenarDataSet("spMovil_ValidarUsuarioEmpleado" + "'" + Usuario + "','" + Pass + "'").Tables[0];
                return dt;
            }
            return null;

        }



        /// <summary>
        /// Metodo Validar Usuario de Aplicación
        /// </summary>
        /// <param name="Usuario">Nombre del Usuario Aplicacion</param>
        /// <param name="Contraseña">Contraseña</param>
        /// <returns>Json[0,1]</returns>
        public DataTable validarUsuarioAplicacion(string Usuario, string Contraseña)
        {
            try
            {
                var objlogin = objDatos.llenarDataSet("spValidarUsuarioSistema '" + Usuario + "','" + Contraseña + "'").Tables[0];
                return objlogin;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para crear 
        /// </summary>
        /// <param name="TipoId"> Tipo de identificacion</param>
        /// <param name="Identificacion"> Cedula Ciudadania</param>
        /// <param name="Nombres">Nombre completos</param>
        /// <param name="Apellidos">Apellidos Completo</param>
        /// <param name="Email">Email</param>
        /// <param name="Clave">Constraseña generadad por la app</param>
        /// <returns>se retorna OK se satisfactorio</returns>         
        public DataTable crearUsuarioMovil(string  TipoId,string  Identificacion ,string  Nombres ,string  Apellidos ,string  Email ,string  Clave, string Token)
        {
            if (Token == "jklminu")
            {
               var  dt = objDatos.llenarDataSet("spMovil_InsertarUsuario" + "'" + TipoId + "','" + Identificacion + "','" + Nombres + "','" + Apellidos + "','" + Email + "','" + Clave + "'").Tables[0];
               return dt;
            }
            return null;
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
        /// Retornar Datos Empleado
        /// </summary>
        /// <param name="Usuario">Usuario Evolution</param>
        /// <param name="contraseña">Contraseña</param>
        /// <param name="Token">Clave</param>
        /// <returns>Datos empleado</returns>
        public DataTable Get(string Usuario, string contraseña, int numero)
        {
            if (numero == 15726)
            {
                contraseña = encriptar(contraseña).ToString().Substring(0,20);
                var dt = objDatos.llenarDataSet("Declare @Cedula varchar(50) Select @cedula = cedula From Usuariossis Where usuario = '" + Usuario + "' and Clave='" + contraseña + "' Select * from evolution_empleados where cedula = @cedula").Tables[0];
                return dt;
            }
            return null;
        }
        

    }
}
