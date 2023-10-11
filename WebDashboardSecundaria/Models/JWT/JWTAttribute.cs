using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebDashboardSecundaria.Models.JWT
{
    public class JWTAttribute : ActionFilterAttribute
    {
        private JWT clave = new JWT();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                string token = actionContext.Request.Headers.Authorization?.Parameter;
                if (string.IsNullOrEmpty(token))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Epoch epoch = new Epoch();
                    double ahora = epoch.convertirEpoch(DateTime.Now);

                    string tokenO = token;
                    string payload = Jose.JWT.Decode(tokenO, clave.GetSecretKey());

                    Claims empleadoJwt = JsonConvert.DeserializeObject<Claims>(payload);

                    if (ahora <= empleadoJwt.Exp)
                    {
                        actionContext.Request.Properties.Add("payload", payload);
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}