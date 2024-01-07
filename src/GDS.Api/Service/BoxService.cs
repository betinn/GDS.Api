﻿using GDS.Api.Model.Request;
using GDS.Api.Model;
using GDS.Api.Service.Interface;
using GDS.Api.Repository.Interface;

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
    }
}
