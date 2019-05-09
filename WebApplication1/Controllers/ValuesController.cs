using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        public static OAuth2Client oauthClient = new OAuth2Client("Q0TMGv2KUfZT5vfgcg0kKBiU1hDvzB3Gv6Ir4vNdDRSVru6O26", "MCUSCRZF8q78uDethITkr875cGEqu8on7kUb33Qa", "", "sandbox"); // environment is “sandbox” or “production”

        public void Get()
        {
            //Prepare scopes
            List<OidcScopes> scopes = new List<OidcScopes>();
            scopes.Add(OidcScopes.Accounting);

            //Get the authorization URL
            string authorizeUrl = oauthClient.GetAuthorizationURL(scopes);

            Redirect(authorizeUrl);
        }

        public void GetCode( string code)
        {
            //Prepare scopes
            var a = 0;
        }
    }
}
