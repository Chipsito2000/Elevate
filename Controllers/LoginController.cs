namespace ElevateERP.Controllers
{
    using ElevateERP.Filtro;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Text.Json;

    public class LoginController : Controller
    {                
        /// <summary>
        /// Redireccion a vista login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {

            return View();

        }

        /// <summary>
        /// Validacion de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(string User, string Clave)
        {
            //validacion
            try
            {
                //validamos el modelo con el de la conexion a la bdd
                using (Models.ElevateErpContext dbo = new Models.ElevateErpContext())
                {
                    //consulta de usuario
                    var oUsuario = (from d 
                                    in dbo.Usuarios 
                                    where d.Usuario1 == User.Trim() && d.Clave == Clave.Trim() 
                                    select d).FirstOrDefault();

                    //Usuario no encontrado
                    if (oUsuario == null)
                    {
                        //Error
                        ViewBag.Error(" No existe el usuario");
                        return View();

                    }

                    HttpContext.Session.SetObject("User", oUsuario);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, oUsuario.Usuario1)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuthenticationScheme");
                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync("MyCookieAuthenticationScheme", new ClaimsPrincipal(claimsIdentity), authProperties);


                }
                //Si existe redirige a pagina principal
                return (RedirectToAction("index", "Home"));

            }
            //Si no es asi manda error
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View();
            }
            
        }      
    }
}
