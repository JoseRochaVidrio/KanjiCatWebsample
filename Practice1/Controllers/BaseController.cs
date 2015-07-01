using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Helpers.SecurityHelper.UserIsAuthenticated())
            {
                ViewBag.NombreUsuario = User.Identity.Name;
            }

            base.OnActionExecuting(filterContext);

            
        }
    }
}