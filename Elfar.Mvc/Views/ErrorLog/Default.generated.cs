﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elfar.Mvc.Views.ErrorLog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Elfar;
    using Elfar.Mvc;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ErrorLog/Default.cshtml")]
    public partial class Default : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Default()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n    <head>\r\n        <title>Error Logging Filter and Rout" +
"e</title>\r\n        <link href=\"");


            
            #line 5 "..\..\Views\ErrorLog\Default.cshtml"
               Write(Url.Content("~/Styles/StyleSheet.css"));

            
            #line default
            #line hidden
WriteLiteral("\" type=\"text/css\" rel=\"stylesheet\" />\r\n    </head>\r\n    <body>\r\n        <header>\r" +
"\n            <div id=\"elfar\">Error Logging Filter and Route &nbsp;/&nbsp; <stron" +
"g title=\"The name or id of the web application\">");


            
            #line 9 "..\..\Views\ErrorLog\Default.cshtml"
                                                                                                                          Write(ErrorLogProvider.Application);

            
            #line default
            #line hidden
WriteLiteral("</strong> &nbsp;/&nbsp; <strong title=\"The name of the server\">");


            
            #line 9 "..\..\Views\ErrorLog\Default.cshtml"
                                                                                                                                                                                                                      Write(Server.MachineName);

            
            #line default
            #line hidden
WriteLiteral(@"</strong></div>
            <ul id=""tabs"">
                <li class=""selected"">Dashboard</li>
            </ul>
        </header>
        <div id=""content"">
            <div id=""dashboard"">
                <p>
                    Trends:
                    <ul>
                        <li>90 days</li>
                        <li>30 days</li>
                        <li>7 days</li>
                        <li>today</li>
                    </ul>
                </p>
                <p>
                    Donut charts:
                    <ul>
                        <li>Areas</li>
                        <li>Controllers (per Area)</li>
                        <li>Actions (per Controller & Area)</li>
                    </ul>
                </p>
                <p>
                    List:
                    <ul>
                        <li>last 10 errors</li>
                        <li>10 most common errors</li>
                    </ul>
                </p>
            </div>
            ");



WriteLiteral("\r\n        </div>\r\n        <footer>Error Logging Filter and Route (v");


            
            #line 129 "..\..\Views\ErrorLog\Default.cshtml"
                                             Write(this.Version());

            
            #line default
            #line hidden
WriteLiteral(") &#169; 2012&ndash;");


            
            #line 129 "..\..\Views\ErrorLog\Default.cshtml"
                                                                                 Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral("  Beyond395 Limited &nbsp;&middot;&nbsp; All rights reserved</footer>\r\n");


        }
    }
}
#pragma warning restore 1591
