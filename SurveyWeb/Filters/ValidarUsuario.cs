using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyWeb.Filters
{
    public class ValidarUsuario : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var nomeController = (string)context.RouteData.Values["controller"];
            //var nomeAction = (string)context.RouteData.Values["action"];
            //var ipCliente = context.HttpContext.Connection.RemoteIpAddress;
            //var browser = context.HttpContext.Request.Headers["User-Agent"].ToString();
            //var urlReferrer = context.HttpContext.Request.Headers["Referer"].ToString();

            if (context.HttpContext.Request.Cookies["idUsuario"] == null || 
                context.HttpContext.Request.Cookies["idUsuario"] == "")
            {
                context.Result = new RedirectResult("/Home/Logout");
            }
        }
    }
}
