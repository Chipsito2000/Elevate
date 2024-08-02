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
    public class Validar_Permiso : AuthorizeAttribute, IAuthorizationFilter
    {
      
        //Crreacion de objetos, conexion y variables
        private Usuario oUsuario;
        private readonly ElevateErpContext _context;
        private int idAccion;


        /// <summary>
        /// Aasigna la variable en el constructor de la clase
        /// </summary>
        /// <param name="idAccion"></param>
        public Validar_Permiso (int idAccion)
        {
            this.idAccion = idAccion;
            _context = new ElevateErpContext();

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

                // Validacion de autenticacion
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectToActionResult("Login", "Login", null);
                    return;
                }



                //validacion de usuario existente
                if (oUsuario == null)
                {
                    filterContext.Result = new RedirectToActionResult("Login", "Login", null);
                    return;
                }

                //consulta para validar permisos de usuario
                var listPermiso = (from P in _context.Permisos
                                   where P.IdRol == oUsuario.IdRol && P.IdAccion == idAccion
                                   select P);

                //sentencia para permisos
                if (listPermiso.ToList().Count == 0)
                {
                    var oAccion = _context.Accions.Find(idAccion);
                    int? idPantalla = oAccion?.IdPantalla;
                    NombreAccion = GetNombreAccion(idAccion);
                    NombrePantalla = GetNombrePantalla(idPantalla);

                    filterContext.Result = new RedirectToActionResult("ErrorOperacion", "Error", null);

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectToActionResult("ErrorOperacion", "Error", null);
            }
        }


        /// <summary>
        /// Obtener la accion
        /// </summary>
        /// <param name="idAccion"></param>
        /// <returns></returns>
        public string GetNombreAccion(int idAccion)
        {
            //validar la accion
            var accion = _context.Accions
                             .Where(a => a.Id == idAccion)
                             .Select(a => a.Accion1)
                             .FirstOrDefault();

            return accion ?? " ";

        }


        /// <summary>
        /// obtener la pantalla
        /// </summary>
        /// <param name="idPantalla"></param>
        /// <returns></returns>
        public string GetNombrePantalla(int? idPantalla)
        {

            //validar la accion
            if (idPantalla == null) return " ";

            var pantalla = _context.Pantallas
                                   .Where(pa => pa.Id == idPantalla)
                                   .Select(pa => pa.NPantalla)
                                   .FirstOrDefault();

            return pantalla ?? " ";
        }
    }
}
