using GDS.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Authentication;

namespace GDS.Api.Filter.Attribute
{
    public class ProfileAuthorizationAttribute : TypeFilterAttribute
    {
        public ProfileAuthorizationAttribute() : base(typeof(ActionAuthorizationBusiness))
        {
        }
    }
    public class ActionAuthorizationBusiness : IAuthorizationFilter
    {
        public static readonly bool _PersistLogin = false;
        public static DateTime? _PersistUntil { get; set; }
        private static string _PasswordAuth { get; set; }
        public static Guid _ProfileAuthenticated { get; set; }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_ProfileAuthenticated == Guid.Empty)
            {
                throw new AuthorizationException();
            }
        }
    }
}
