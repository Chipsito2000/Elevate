namespace ElevateERP.Controllers
{
    using ElevateERP.Data;
    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Text.Json;

    public class LoginController : Controller
    {            
        
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

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
                
                    //consulta de usuario
                    var oUsuario = (from d 
                                    in _context.Usuarios 
                                    where d.Usuario1 == User.Trim() && d.Clave == Clave.Trim() 
                                    select d).FirstOrDefault();


                    if (oUsuario != null)
                    {
                        // Almacenar el usuario en la sesión
                        HttpContext.Session.SetObject("User", oUsuario);
                    }else 
                    {
                        //Error
                        ViewBag.Error(" No existe el usuario");
                        return View();

                    }


                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, oUsuario.Usuario1)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuthenticationScheme");
                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync("MyCookieAuthenticationScheme", new ClaimsPrincipal(claimsIdentity), authProperties);


                
                //Si existe redirige a pagina principal
                return (RedirectToAction("index", "Home"));

            }
            //Si no es asi manda error
            catch (Exception )
            {
                ViewBag.Error = "No se reconoce el usuario"; 
                return View();
            }
            
        }      
    }
}
