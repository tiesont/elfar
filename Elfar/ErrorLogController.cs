﻿using System;
using System.Web.Mvc;
using Elfar.ActionResults;
using Elfar.Models;

namespace Elfar
{
    class ErrorLogController
        : AsyncController
    {
        public ErrorLogController(
            IErrorLogProvider provider)
        {
            this.provider = provider;
        }

        public DefaultResult Default(Guid id)
        {
            return new DefaultResult(id, provider, e => View(new Default { ErrorLog = e }));
        }
        public RssResult Digest()
        {
            return new RssResult(900, provider);
        }
        public void DownloadAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            var csv = new Csv(provider, Request.Url);
            csv.Complete += (src, e) =>
            {
                AsyncManager.Parameters["csv"] = e.UserState;
                AsyncManager.OutstandingOperations.Decrement();
            };
            csv.Load();
        }
        public CsvResult DownloadCompleted(Csv csv)
        {
            return new CsvResult { Data = csv };
        }
        public DefaultResult Html(Guid id)
        {
            return new DefaultResult(id, provider, e => Content(e.Html));
        }
        public FileStreamResult Image(string name)
        {
            return ResourceFile(name, "png", "image/png");
        }
        public IndexResult Index()
        {
            return new IndexResult(1, int.MaxValue, provider, RedirectToAction);
        }
        public FileStreamResult JavaScript()
        {
            return ResourceFile("JavaScript", "js", "text/javascript");
        }
        public DefaultResult Json(Guid id)
        {
            return new DefaultResult(id, provider, e => Json(e, JsonRequestBehavior.AllowGet));
        }
        public RssResult Rss()
        {
            return new RssResult(15, provider);
        }
        public FileStreamResult Stylesheet()
        {
            return ResourceFile("Stylesheet", "css", "text/css");
        }
        public void Test()
        {
            throw new TestException();
        }
        public DefaultResult Xml(Guid id)
        {
            return new DefaultResult(id, provider, e => new XmlResult { Data = e });
        }

        FileStreamResult ResourceFile(string name, string ext, string contentType)
        {
            return File(GetType().Assembly.GetManifestResourceStream("Elfar.Resources." + name + "." + ext), contentType);
        }

        readonly IErrorLogProvider provider;
    }
}