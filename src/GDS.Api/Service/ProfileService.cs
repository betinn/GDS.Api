using GDS.Api.Model;
using GDS.Api.Model.Exceptions;
using GDS.Api.Model.Request;
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
        public List<string> ListProfilesFromBaseDiretory()
        {
            return Directory.GetFiles(_profileRepository.GetBaseDiretoryFromAppConfig()).ToList();
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
                string.Format("{0}_{1}{2}", 
                profileEncrypted.Name, 
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
        public Profile CreateBox(Guid idcard, CreateBoxRequest boxRequest)
        {
            return _profileRepository.AddBox(idcard, boxRequest);

        }

        
        #region private methods


        #endregion
    }
}
