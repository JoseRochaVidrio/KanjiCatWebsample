using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentSecurity;
using System.Web.Mvc;

namespace Practice1.Helpers
{
    public class DefaultPolicyHandler : IPolicyViolationHandler
    {

        public System.Web.Mvc.ActionResult Handle(PolicyViolationException exception)
        {
            if (Helpers.SecurityHelper.UserIsAuthenticated())
            {
                return new ViewResult { ViewName = "Error" };
            }
            else
            {
                return new HttpUnauthorizedResult(exception.Message);
            }
        }
    }
}