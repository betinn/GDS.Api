using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Repository.Interface
{
    public interface IProfileRepository
    {
        void SaveProfile(Profile profile, ProfileSecrets profileSecrets);
        string GetBaseDiretoryFromAppConfig();
        Profile GetDecryptedProfile(ProfileSecrets profileSecrets);
        void Delete(string oldFileName);
    }
}
