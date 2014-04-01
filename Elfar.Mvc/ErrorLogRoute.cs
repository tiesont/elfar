﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Async;
using System.Web.Routing;

namespace Elfar.Mvc
{
    public class ErrorLogRoute
    {
        class _Route : Route
        {
            public _Route() : base
            (
                "elfar/{action}",
                new RouteValueDictionary { { "action", "Default" }, { "controller", "ErrorLog" }, { "namespaces", new[] { "Elfar" } } },
                new RouteValueDictionary(ErrorLogRoute.Constraints.Where(c => c != null).ToDictionary(k => string.Empty, c => (object) c)),
                new _RouteHandler()
            ) {}

            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                return css.GetRouteData(httpContext)
                    ?? js.GetRouteData(httpContext)
                    ?? base.GetRouteData(httpContext);
            }

            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
            {
                return css.GetVirtualPath(requestContext, values)
                    ?? js.GetVirtualPath(requestContext, values)
                    ?? base.GetVirtualPath(requestContext, values);
            }

            static readonly Route css = new Route("elfar/{filename}.css", new RouteValueDictionary { { "action", "StyleSheet" } }, new _RouteHandler());
            static readonly Route js = new Route("elfar/{filename}.js", new RouteValueDictionary { { "action", "JavaScript" } }, new _RouteHandler());

            class _RouteHandler : IRouteHandler
            {
                public IHttpHandler GetHttpHandler(RequestContext requestContext)
                {
                    return new Handler(requestContext);
                }

                class Handler : IHttpAsyncHandler
                {
                    public Handler(RequestContext requestContext)
                    {
                        this.requestContext = requestContext;
                        controller = new ErrorLogController();
                    }

                    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
                    {
                        return controller.BeginExecute(requestContext, cb, extraData);
                    }
                    public void EndProcessRequest(IAsyncResult result)
                    {
                        controller.EndExecute(result);
                    }
                    public void ProcessRequest(HttpContext context)
                    {
                        controller.Execute(requestContext);
                    }

                    public bool IsReusable
                    {
                        get { return false; }
                    }

                    readonly IAsyncController controller;
                    readonly RequestContext requestContext;
                }
            }
        }

        public static implicit operator Route(ErrorLogRoute route)
        {
            return new _Route();
        }

        public static IEnumerable<IRouteConstraint> Constraints
        {
            get { return constraints ?? (constraints = empty); }
            set { constraints = value; }
        }

        static IEnumerable<IRouteConstraint> constraints;
        static readonly IRouteConstraint[] empty = new IRouteConstraint[0];
    }
}