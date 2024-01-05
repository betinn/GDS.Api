using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface IProfileService
    {
        List<string> ListProfilesFromBaseDiretory();
        void CreateProfile(CreateProfileRequest request);
    }
}
