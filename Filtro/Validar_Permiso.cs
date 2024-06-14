namespace ElevateERP.Filtro
{

    using ElevateERP.Models;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;


    /// <summary>
    /// Filtro para validar los permisos de usuario
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class Validar_Permiso : AuthorizeAttribute
    {
      
        //Crreacion de objetos, conexion y variables
        private Usuario oUsuario;        
        private ElevateErpContext dbo = new ElevateErpContext();
        private int idAccion;


        /// <summary>
        /// Aasigna la variable en el constructor de la clase
        /// </summary>
        /// <param name="idAccion"></param>
        public Validar_Permiso (int idAccion = 0)
        {
            this.idAccion = idAccion;
        }

        /// <summary>
        /// Metodo para obtener el permiso y accion asignado
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            //variables 
            string NombreAccion = "";
            string NombrePantalla = "";

            try
            {
                //Tomamos la sesion creada al iniciar sesion
                oUsuario = filterContext.HttpContext.Session.GetObject<Usuario>("User");

                //// Validacion de autenticacion
                //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                //{
                //    filterContext.Result = new RedirectToActionResult("Login", "Login", null);
                //    return;
                //}

               

                //validacion de usuario existente
                if (oUsuario == null)
                {
                    filterContext.Result = new RedirectToActionResult("Login", "Login", null);
                    return;
                }

                //consulta para validar permisos de usuario
                var listPermiso = (from P in dbo.Permisos
                                   where P.IdRol == oUsuario.IdRol && P.IdAccion == idAccion
                                   select P);

                //sentencia para permisos
                if (listPermiso.ToList().Count == 0)
                {
                    var oAccion = dbo.Accions.Find(idAccion);
                    int? idPantalla = oAccion?.IdPantalla;
                    NombreAccion = GetNombreAccion(idAccion);
                    NombrePantalla = GetNombrePantalla(idPantalla);

                    filterContext.Result = new RedirectResult("~/Error/ErrorOperacion?Accion=" + NombreAccion);
                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/ErrorOperacion?Accion=" + NombreAccion);
            }
        }


        /// <summary>
        /// Obtener la accion
        /// </summary>
        /// <param name="idAccion"></param>
        /// <returns></returns>
        public string GetNombreAccion(int idAccion)
        {
            //Consultar el nombre de la accion Lmbda
            var accion = from a in dbo.Accions
                         where a.Id == idAccion
                         select a.Accion1;

            //validar la accion
            try
            {   //Si tiene la muestra 
                return accion.First();
            }
            catch (Exception)
            {
                //Si no tiene no muestra nada
                return " ";
            }
        }


        /// <summary>
        /// obtener la pantalla
        /// </summary>
        /// <param name="idPantalla"></param>
        /// <returns></returns>
        public string GetNombrePantalla(int? idPantalla)
        {
            //Consultar el nombre de la accion Lmbda
            var Pantalla = from Pa in dbo.Pantallas
                           where Pa.Id == idPantalla
                           select Pa.NPantalla;

            //validar la accion
            try
            {   //muestra la pantalla
                return Pantalla.First();
            }
            catch (Exception)
            {
                //No muestra nada
                return " ";
            }
        }
    }
}
