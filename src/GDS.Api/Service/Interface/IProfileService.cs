using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface IProfileService
    {
        List<string> ListProfilesFromBaseDiretory();
        void CreateProfile(CreateProfileRequest request);
        Profile DecryptProfile(AuthProfileRequest authProfile);
        Profile CreateBox(Guid idcard, CreateBoxRequest boxRequest);
    }
}
