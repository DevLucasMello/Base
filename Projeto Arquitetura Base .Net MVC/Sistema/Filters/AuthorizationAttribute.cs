using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sistema.Models;

namespace Sistema.Filters
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public AuthorizationAttribute()
        {
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IIdentity identity = httpContext.User.Identity;
            var authenticatedUserModel = AuthenticatedUserModel.GetFromJSON(identity.Name);
            if (authenticatedUserModel != null && identity.IsAuthenticated)
            {
                return true;
            }
            httpContext.Response.Redirect(FormsAuthentication.LoginUrl);
            return false;
        }
    }

}