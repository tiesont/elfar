﻿using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Routing;

namespace Elfar.Web.Mvc
{
    sealed class ErrorLog : Elfar.ErrorLog
    {
        public ErrorLog(Exception exception, RouteData data, HttpContextBase context) : base(exception)
        {
            var httpException = exception as HttpException;

            if(httpException != null)
            {
                Code = httpException.GetHttpCode();
                Html = Regex.Replace(httpException.GetHtmlErrorMessage() ?? "", @"\s*[<>{}]\s*", m => m.Value.Trim());
            }

            if(data != null)
            {
                var route = data.Route as Route;
                if (route != null)
                {
                    RouteConstraints = new Dictionary(route.Constraints);
                    RouteDefaults = new Dictionary(route.Defaults);
                    RouteUrl = route.Url;
                }

                RouteData = new Dictionary(data.Values);
                DataTokens = new Dictionary(data.DataTokens);

                Action = data.GetRequiredString("action").ToPascal();
                Controller = data.GetRequiredString("controller").ToPascal();
                Area = DataTokens.ContainsKey("area") ? DataTokens["area"].ToPascal() : "";
            }

            if (context == null) return;

            try { Host = context.Server.MachineName; }
            catch(HttpException) { }

            var user = context.User;
            if(!(user == null || string.IsNullOrWhiteSpace(user.Identity.Name))) User = user.Identity.Name;

            var request = context.Request;

            Url = request.Url;
            HttpMethod = request.HttpMethod;

            var unvalidated = request.Unvalidated();

            Cookies = request.Cookies;
            Form = unvalidated.Form;
            QueryString = unvalidated.QueryString;
            ServerVariables = request.ServerVariables;
        }
    }
}