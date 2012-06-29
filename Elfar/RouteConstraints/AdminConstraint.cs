﻿namespace Elfar.RouteConstraints
{
    using System.Web;
    using System.Web.Routing;
    using System.Web.Security;

    public class AdminConstraint
        : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var user = httpContext.User;
            return httpContext.Request.IsAuthenticated && (user.IsInRole("Admin") || user.IsInRole("Administrator") || user.IsInRole("Administration"));
        }
    }
}