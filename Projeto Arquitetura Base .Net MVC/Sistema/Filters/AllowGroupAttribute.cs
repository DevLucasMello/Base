using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sistema.Models;

namespace Sistema.Filters
{
    public class AllowGroupAttribute : AuthorizeAttribute
    {
        public List<string> GroupName { get; set; }

        public AllowGroupAttribute(string groupName)
        {
            this.GroupName = groupName.Split('|').ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                var authenticatedUserModal = AuthenticatedUserModel.GetFromJSON(httpContext.User.Identity.Name);
                if (authenticatedUserModal.AccessGroups.Any(g => this.GroupName.Any(n => n.ToLowerInvariant() == g.ToLowerInvariant())))
                {
                    return true;
                }
            }
            httpContext.Response.Redirect(FormsAuthentication.LoginUrl);
            return false;
        }
    }

}