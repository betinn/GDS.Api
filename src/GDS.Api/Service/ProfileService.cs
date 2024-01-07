using GDS.Api.Model;
using GDS.Api.Model.Exceptions;
using GDS.Api.Model.Request;
using GDS.Api.Model.Response;
using GDS.Api.Repository.Interface;
using GDS.Api.Service.Interface;
using GDS.Api.Util;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace GDS.Api.Service
{
    public class ProfileService(IAuthService authService, IProfileRepository profileRepository) : IProfileService
    {
        private readonly IAuthService _authService = authService;
        private readonly IProfileRepository _profileRepository = profileRepository;
        private readonly string _extension = ".gdsprofile";
        public List<ListProfilesResponse> ListProfilesFromBaseDiretory()
        {
            var files = Directory.GetFiles(_profileRepository.GetBaseDiretoryFromAppConfig()).ToList();
            var response = new List<ListProfilesResponse>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                var profile = JsonConvert.DeserializeObject<ProfileEncrypted>(File.ReadAllText(file));
                response.Add(new ListProfilesResponse() { FileName = fileInfo.Name, Name = profile.Name, Img = profile.ImgBase64 });
            }

            return response;
        }

        public void CreateProfile(CreateProfileRequest request)
        {
            //gera exemplo para o profile sendo criado
            var exemploCard = new Card(Guid.NewGuid(),
                "Exemplo"
                );
            var exemploBox1 = new Box(
                    Guid.NewGuid(),
                    "Exemplo de Nome",
                    false,
                    "exemplo@email.com");
            var exemploBox2 = new Box(
                Guid.NewGuid(),
                "Exemplo box segredo",
                true,
                "sua senha escondida");

            exemploCard.Boxes.Add(exemploBox1);
            exemploCard.Boxes.Add(exemploBox2);
            // 



            Profile profile = new Profile(request.Name,
                DateTime.Now,
                DateTime.Now);
            profile.Cards.Add(exemploCard);
            
            ProfileEncrypted profileEncrypted =
                new ProfileEncrypted(
                profile.Name,
                profile.ImgBase64,
                Criptography.EncryptStringToBytes_Aes(
                    profile.Cards.ToJson(),
                    request.User, //user e password precisam ter lengh iguais para funcionar.
                    request.Password),
                profile.CreatedOn,
                profile.LastChanged
                );


            var baseDir = _profileRepository.GetBaseDiretoryFromAppConfig();

            if( !Directory.Exists(baseDir) ) {  Directory.CreateDirectory(baseDir); }

            var fileToCreate = Path.Combine(baseDir,
                string.Format("{0}{1}", 
                Guid.NewGuid(), 
                _extension));

            File.WriteAllText(fileToCreate, profileEncrypted.ToJson());
        }
        public Profile DecryptProfile(AuthProfileRequest authProfile)
        {
            var fileProfile = Path.Combine(_profileRepository.GetBaseDiretoryFromAppConfig(), authProfile.ProfileFilePath);
            if (!File.Exists(fileProfile))
            {
                throw new ArgumentException("Caminho não encontrado para o profile indicado", authProfile.ProfileFilePath);
            }

            var profileEncrypted = 
                JsonConvert.DeserializeObject<ProfileEncrypted>(
                File.ReadAllText(fileProfile));

            if( profileEncrypted == null )
            {
                throw new ArgumentNullException(nameof(profileEncrypted));
            }

            Profile profileDecrypt = new Profile(
                profileEncrypted.Name, 
                profileEncrypted.CreatedOn,
                profileEncrypted.LastChanged,
                profileEncrypted.ImgBase64
                );

            var cards = Criptography.DecryptStringFromBytes_Aes(
                profileEncrypted.Cards, 
                authProfile.User, 
                authProfile.Password);

            profileDecrypt.Cards = cards.JsonToObject<List<Card>>();

            return profileDecrypt;

        }

        public Profile Update(UpdateProfileRequest updateProfileRequest)
        {
            var profileSecrets = _authService.GetProfileSecrets();
            var profile = _profileRepository.GetDecryptedProfile(profileSecrets);


            profile.Name = updateProfileRequest.Name;
            if(profile.ImgBase64 != null)
            {
                profile.ImgBase64 = profile.ImgBase64;
            }

            _profileRepository.SaveProfile(profile, profileSecrets);


            return profile;
        }

        

        #region private methods



        #endregion
    }
}
