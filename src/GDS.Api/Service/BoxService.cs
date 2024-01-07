using GDS.Api.Model.Request;
using GDS.Api.Model;
using GDS.Api.Service.Interface;
using GDS.Api.Repository.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GDS.Api.Service
{
    public class BoxService(IBoxRepository boxRepository, 
        IProfileRepository profileRepository,
        IHttpContextAccessor contextAccessor,
        IServiceProvider serviceProvider) : 
        BaseService(contextAccessor, serviceProvider), IBoxService
    {
        private readonly IBoxRepository _boxRepository = boxRepository;
        private readonly IProfileRepository _profileRepository = profileRepository;
        public Profile Create(Guid idcard, CreateBoxRequest boxRequest)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _boxRepository.AddBox(idcard, boxRequest, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);

            return profile;
        }

        public Profile Delete(Guid idCard, Guid idBox)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _boxRepository.Delete(idCard, idBox, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);

            return profile;
        }

        public Profile Update(Guid idCard, Guid idBox, CreateBoxRequest boxRequest)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _boxRepository.Update(idCard, idBox, boxRequest, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);

            return profile;
        }
    }
}
