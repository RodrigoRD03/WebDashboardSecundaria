using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDashboardSecundaria.Models.JWT
{
    public class FiterJWTAttribute : ActionFilterAttribute
    {
        private JWT clave = new JWT();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //string token = filterContext.HttpContext.Request.Headers["Authorization"]?.Substring(7);
                string token = filterContext.HttpContext.Session["JWT"] as string;
                string view = filterContext.HttpContext.Session["View"] as string;
                if (string.IsNullOrEmpty(token))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        {
                            {"controller", "Usuarios"}, // Nombre de tu controlador de inicio de sesión
                            {"action", "InicioSesion"} // Nombre del método para mostrar la vista de inicio de sesión
                        });
                    //filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Epoch epoch = new Epoch();
                    double ahora = epoch.convertirEpoch(DateTime.Now);

                    string tokenO = token;
                    string payload = Jose.JWT.Decode(tokenO, clave.GetSecretKey());
                    Claims empleadoJwt = JsonConvert.DeserializeObject<Claims>(payload);

                    //Accesos
                    //if (empleadoJwt.uap[int.Parse(view) - 1] == '0')
                    //{
                    //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    //    {
                    //        {"controller", "Usuarios"}, // Nombre de tu controlador de inicio de sesión
                    //        {"action", "InicioSesion"} // Nombre del método para mostrar la vista de inicio de sesión
                    //    });
                    //    //filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    //    return;
                    //}
                    if (ahora <= empleadoJwt.Exp)
                    {
                        filterContext.HttpContext.Items["payload"] = payload;
                    }
                    else
                    {
                        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}