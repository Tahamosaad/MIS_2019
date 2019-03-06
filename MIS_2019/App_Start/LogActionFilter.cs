using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS_2019.App_Start
{
    public class LogActionFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception !=null)
            {
                File.AppendAllText(filterContext.HttpContext.Server.MapPath("~/Log.txt"),filterContext.Exception.ToString());
            }
        }     
    }
}