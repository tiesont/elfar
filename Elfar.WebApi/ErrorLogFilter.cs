﻿using System;
using System.ComponentModel.Composition;
using System.Web.Http.Filters;

using errorlog = Elfar.ErrorLog;

namespace Elfar.WebApi
{
    [Export]
    public class ErrorLogFilter : ExceptionFilterAttribute
    {
        static ErrorLogFilter()
        {
            Settings = new ErrorLogFilterSettings();
        }

        [ImportingConstructor]
        public ErrorLogFilter(IErrorLogProvider provider)
        {
            this.provider = provider;
            if(Settings == null) Settings = new ErrorLogFilterSettings();
        }
        
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;

            if (Exclude(actionExecutedContext)) return;

            var errorLog = new errorlog(provider.Application, exception);

            if (!(exception is ErrorLogException)) TryExecute(provider.Save, errorLog);

            foreach(var plugin in Plugins)
            {
                TryExecute(plugin.Execute, errorLog);
            }
        }

        static bool Exclude(HttpActionExecutedContext actionExecutedContext)
        {
            return Settings.Exclude != null && Settings.Exclude(actionExecutedContext);
        }
        static void TryExecute(Action<errorlog> action, errorlog errorLog)
        {
            try { action(errorLog); }
            catch (Exception) { }
        }

        public static ErrorLogFilterSettings Settings { get; set; }
        
        [ImportMany]
        public IErrorLogPlugin[] Plugins;

        readonly IErrorLogProvider provider;
    }
}