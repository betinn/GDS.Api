using GDS.Api.Model;
using GDS.Api.Model.Request;
using GDS.Api.Repository.Interface;
using GDS.Api.Service.Interface;

namespace GDS.Api.Service
{
    public class CardService(ICardRepository cardRepository,
        IProfileRepository profileRepository,
        IHttpContextAccessor contextAccessor,
        IServiceProvider serviceProvider) : 
        BaseService(contextAccessor, serviceProvider),
        ICardService
    {
        private readonly IProfileRepository _profileRepository = profileRepository;
        private readonly ICardRepository _cardRepository = cardRepository;

        public Profile Create(CreateCardRequest cardRequest)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _cardRepository.Create(cardRequest, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);

            return profile;

        }

        public Profile Delete(Guid idCard)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _cardRepository.Delete(idCard, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);
            return profile;
        }

        public Profile Update(Guid idCard, UpdateCardRequest updateCardRequest)
        {
            var profileSecrets = GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);

            _cardRepository.Update(idCard, updateCardRequest, profile);

            _profileRepository.SaveProfile(profile, profileSecrets);
            return profile;
        }
    }
}
