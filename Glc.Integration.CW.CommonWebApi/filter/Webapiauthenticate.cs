using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Filters;

namespace Glc.Integration.CW.CommonWebApi.filter
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public void OnAuthorization(HttpRequestMessage actionContext)
        {
            var authHeader = actionContext.Headers.Authorization;
            HttpResponseMessage result = null;
            if (authHeader != null)
            {
                var authenticationToken = actionContext.Headers.Authorization.Parameter;
                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                var usernamePasswordArray = decodedAuthenticationToken.Split(':');
                var userName = usernamePasswordArray[0];
                var password = usernamePasswordArray[1];

                // Replace this with your own system of security / means of validating credentials
                var isValid = userName == "GLCGDSTESTAPI" && password == "GDS_Xxsw$23";

                if (isValid)
                {
                    var principal = new GenericPrincipal(new GenericIdentity(userName), null);
                    Thread.CurrentPrincipal = principal;

                    result =
                       actionContext.CreateResponse(HttpStatusCode.OK,
                          "User " + userName + " successfully authenticated");

                    return;
                }
            }

           HandleUnathorized(actionContext);
        }

        private static void HandleUnathorized(HttpRequestMessage actionContext)
        {
             actionContext.CreateResponse(HttpStatusCode.Unauthorized);
             actionContext.Headers.Add("WWW-Authenticate", "Basic Scheme='Data' location = 'http://localhost:");
        }
    }
}