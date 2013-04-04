﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Elfar.Web.App_Start.Elfar), "Init")]
namespace Elfar.Web.App_Start
{
    public static class Elfar
    {
        public static void Init()
        {
            //global::Elfar.Settings.Application = null;
            //global::Elfar.Settings.ConnectionString = null;
            //global::Elfar.Settings.Path = null;
            //global::Elfar.Mvc.Settings.Constraints = null;
            //global::Elfar.Mvc.Settings.Exclude = null;
            global::Elfar.Mail.Settings.To = "a@aa.aaa";

            UpdateViewEngines(ViewEngines.Engines);

            RouteTable.Routes.MapRoute("", "", new { controller = "Default", action = "Default" });
        }

        static void UpdateViewEngines(ICollection<IViewEngine> engines)
        {
            var engine = engines.FirstOrDefault(e => e is WebFormViewEngine);
            if(engine != null) engines.Remove(engine);
        }
    }
}