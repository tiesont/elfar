﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Elfar.Web.Mvc
{
    public class Minify : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            if (response.ContentType == "text/html" && response.Filter != null)
            {
                response.Filter = new RemoveWhitespacesStream(response.Filter);
            }
        }

        class RemoveWhitespacesStream : Stream
        {
            public RemoveWhitespacesStream(Stream inner)
            {
                this.inner = inner;
            }

            public override void Flush()
            {
                inner.Flush();
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                buffer = Encoding.UTF8.GetBytes(regex.Replace(Encoding.UTF8.GetString(buffer, offset, count), string.Empty));
                inner.Write(buffer, 0, buffer.Length);
            }

            public override bool CanRead => false;
            public override bool CanSeek => false;
            public override bool CanWrite => true;
            public override long Length
            {
                get { throw new NotSupportedException(); }
            }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }

            readonly Stream inner;
            static readonly Regex regex = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
        }
    }
}