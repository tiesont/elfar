﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elfar.Views.ErrorLog.DisplayTemplates
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
    using Elfar.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ErrorLog/DisplayTemplates/Collection.cshtml")]
    public class Collection : System.Web.Mvc.WebViewPage<Elfar.Collection>
    {
        public Collection()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
 if(Model.Count != 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <table cellspacing=\"0\">\r\n        <thead>\r\n            <tr>\r\n                <" +
"th style=\"width: 20%;\">Name</th>\r\n                <th style=\"width: 80%;\">Value<" +
"/th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");


            
            #line 12 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
               var i = 0; 

            
            #line default
            #line hidden

            
            #line 13 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
             foreach(var key in Model.Keys)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr class=\"");


            
            #line 15 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
                       Write(i++ % 2 == 0 ? "odd" : "even");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <td class=\"key-col\">");


            
            #line 16 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
                                   Write(key);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");


            
            #line 17 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
                   Write(Model[key]);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                </tr>\r\n");


            
            #line 19 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 22 "..\..\Views\ErrorLog\DisplayTemplates\Collection.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
