using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice1.Helpers
{
    public class SecurityHelper
    {
        public static bool UserIsAuthenticated()
        {
            var currentUser = HttpContext.Current.User;
            return !string.IsNullOrEmpty(currentUser.Identity.Name);
        }
    }
}