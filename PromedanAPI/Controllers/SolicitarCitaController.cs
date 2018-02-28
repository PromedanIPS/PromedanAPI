using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using PromedanAPI.BD;

namespace PromedanAPI.Controllers
{
    public class SolicitarCitaController : ApiController
    {

        AccesoDatos objDatos = new AccesoDatos();

        // GET: api/SolicitarCita
        public DataTable Get()
        {
            var dt = objDatos.llenarDataSet("spcostos_ServiciosIPS_ObtenerxEmail").Tables[0];
            return dt;
        }
        
               
       
        ///    
        public DataTable solicitarCitaWeb(string TipoId, string Cedula, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string Email, string Sexo, string TipoAfiliado, string FechaNacimiento, string Direccion, string Telefono, string Celular, string Ips, string CentroAtencion, string Eps, string NumeroOrden, string Servicio, string Observaciones,string EmailMovil, string Token)
        {
            if (Token == "jklminu")
            {
                var dt = objDatos.llenarDataSet("ServicioCliente_CitaWeb_Insertar" + "'" + TipoId + "','" +  Cedula+ "','" +   PrimerNombre+ "','" +  SegundoNombre+ "','" +  PrimerApellido+ "','" +  SegundoApellido+ "','" +  Email+ "','" +  Sexo+ "','" +  TipoAfiliado+ "','" +  FechaNacimiento+ "','" +  Direccion+ "','" +  Telefono+ "','" +  Celular+ "','" +  Ips+ "','" +  CentroAtencion+ "','" +  Eps+ "','" +  NumeroOrden+ "','" +  Servicio+ "','" +  Observaciones +"','" + EmailMovil +"'").Tables[0];
                return dt;
            }
            return null;
        }
        
        /// <summary>
        /// consultar datos de paciente
        /// </summary>
        /// <param name="IdTipoId"></param>
        /// <param name="Identificacion"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        public DataTable obtenerPaciente(string IdTipoId, string Identificacion, string Token)
        {
            if (Token == "jklminu")
            {
                var dt = objDatos.llenarDataSet("spevolution_Usuarios_ConsultarDatosUsr " + "'" + IdTipoId + "','" + Identificacion + "'").Tables[0];
                return dt;
            }
            return null;
        }


        



    }
}
