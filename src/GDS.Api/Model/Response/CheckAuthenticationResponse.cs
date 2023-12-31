using GDS.Api.Filter.Attribute;

namespace GDS.Api.Model.Response
{
    public class CheckAuthenticationResponse
    {
        public bool PersistLogin 
        { 
            get
            {
                return ActionAuthorizationBusiness._PersistLogin;
            }
                
        }
        public DateTime? PersistUntil { get { return ActionAuthorizationBusiness._PersistUntil; } }
        public Guid ProfileAuthenticated {  get { return ActionAuthorizationBusiness._ProfileAuthenticated; } }
    }
}
