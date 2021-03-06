﻿namespace GalaxiaUniversity.Web.Angular
{
    using GalaxiaUniversity.Web.Angular.App_Start;
    using System.Web.Http;
    using System.Web.Mvc;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
