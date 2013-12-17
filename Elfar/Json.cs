﻿using System;
using System.Security;
using System.Threading;
using System.Web.Script.Serialization;

namespace Elfar
{
    public class Json
    {
        public Json(Exception exception)
        {
            if(exception == null) throw new ArgumentNullException("exception");

            Time = DateTime.Now;

            try { Host = Environment.MachineName; }
            catch(SecurityException) { }

            var @base = exception.GetBaseException();

            Message = @base.Message;
            Source = @base.Source;
            StackTrace = @base.ToString();
            Type = @base.GetType().ToString();

            User = Thread.CurrentPrincipal.Identity.Name;

            ID = Math.Abs((Application + Host + Type + Time + User).GetHashCode() + @base.GetHashCode());
        }

        public static implicit operator string(Json json)
        {
            return json.ToString();
        }

        public override string ToString()
        {
            return Serializer.Serialize(this);
        }

        public string Application
        {
            get { return ErrorLogProvider.Settings.Application; }
        }
        public string Host { get; protected set; }
        public int ID { get; private set; }
        public string Message { get; private set; }
        public string Source { get; private set; }
        public string StackTrace { get; private set; }
        public DateTime Time { get; private set; }
        public string Type { get; private set; }
        public string User { get; protected set; }
        
        protected static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
    }
}