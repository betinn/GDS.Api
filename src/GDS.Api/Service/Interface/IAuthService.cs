using GDS.Api.Model;
using GDS.Api.Model.Configuration;
using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface IAuthService
    {
        string CreateAccessToken(CreateTokenRequest authToken);
        ProfileSettings GetProfileSettings();
    }
}
