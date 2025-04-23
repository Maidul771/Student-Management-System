using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Filters
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.Session["UserName"];
            if (user == null)
            {
                // Redirect to login page if session is null (not authenticated)
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}