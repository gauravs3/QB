﻿using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public static OAuth2Client oauthClient = new OAuth2Client("Q0TMGv2KUfZT5vfgcg0kKBiU1hDvzB3Gv6Ir4vNdDRSVru6O26", "MCUSCRZF8q78uDethITkr875cGEqu8on7kUb33Qa", "", "sandbox"); // environment is “sandbox” or “production”

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //Prepare scopes
            List<OidcScopes> scopes = new List<OidcScopes>();
            scopes.Add(OidcScopes.Accounting);
            //Get the authorization URL
            string authorizeUrl = oauthClient.GetAuthorizationURL(scopes);
            Redirect(authorizeUrl);
            return View();
        }


        public ActionResult CallBack()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
