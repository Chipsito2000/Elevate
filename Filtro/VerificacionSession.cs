namespace ElevateERP.Filtro
{
    using ElevateERP.Controllers;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Http;


    /// <summary>
    /// Clase para filtrar la session de uusario
    /// </summary>
    public class VerificacionSession: ActionFilterAttribute
    {
        /// <summary>
        /// Objeto del modelo usuario
        /// </summary>
        private Usuario? oUsuario;

        //Metodo para validar y encapsular la sesion 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //hereda del padre el filtro 
                base.OnActionExecuting(filterContext);

                //toma la sesion
                oUsuario = filterContext.HttpContext.Session.GetObject<Usuario>("User");

                //Filtra la sesion 
                if (oUsuario == null)
                {
                    //if(filterContext.Controller is LoginController == false)
                    //{
                    //   filterContext.HttpContext.Response.Redirect("/Login/Login");
                    //}
                    if (filterContext.Controller is not LoginController)
                    {
                        filterContext.Result = new RedirectToActionResult("Login", "Login", null);
                    }
                }

            }
            catch (Exception)
            {
                //filterContext.Result = new RedirectResult("~/Login/Login");
                filterContext.Result = new RedirectToActionResult("Login", "Login", null);

            }
        }       
    }
}
