using GDS.Api.Model;
using GDS.Api.Model.Request;
using GDS.Api.Model.Response;

namespace GDS.Api.Service.Interface
{
    public interface IProfileService
    {
        List<ListProfilesResponse> ListProfilesFromBaseDiretory();
        void CreateProfile(CreateProfileRequest request);
        Profile DecryptProfile(AuthProfileRequest authProfile);
        Profile Update(UpdateProfileRequest updateProfileRequest);
    }
}
