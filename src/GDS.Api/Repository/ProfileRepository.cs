using GDS.Api.Model;
using GDS.Api.Model.Exceptions;
using GDS.Api.Model.Request;
using GDS.Api.Repository.Interface;
using GDS.Api.Service.Interface;
using GDS.Api.Util;
using Newtonsoft.Json;

namespace GDS.Api.Repository
{
    public class ProfileRepository(IAuthService authService) : BaseRepository, IProfileRepository
    {
        

        public void SaveProfile(Profile profile, ProfileSecrets profileSecrets)
        {
            profile.LastChanged = DateTime.Now;
            ProfileEncrypted profileEncrypted =
                new ProfileEncrypted(
                profile.Name,
                profile.ImgBase64,
                Criptography.EncryptStringToBytes_Aes(
                    profile.Cards.ToJson(),
                    profileSecrets.User, //user e password precisam ter lengh iguais para funcionar.
                    profileSecrets.Password),
                profile.CreatedOn,
                profile.LastChanged
                );


            var baseDir = GetBaseDiretoryFromAppConfig();

            if (!Directory.Exists(baseDir)) { Directory.CreateDirectory(baseDir); }

            var fileToWrite = Path.Combine(baseDir,
                profile.FileName);

            File.WriteAllText(fileToWrite, profileEncrypted.ToJson());
        }


        public Profile GetDecryptedProfile(ProfileSecrets profileSettings)
        {
            
            var fileProfile = Path.Combine(GetBaseDiretoryFromAppConfig(), profileSettings.ProfileFileName);
            if (!File.Exists(fileProfile))
            {
                throw new ArgumentException("Caminho não encontrado para o profile indicado", profileSettings.ProfileFileName);
            }

            var profileEncrypted =
                JsonConvert.DeserializeObject<ProfileEncrypted>(
                File.ReadAllText(fileProfile));

            if (profileEncrypted == null)
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
                profileSettings.User,
                profileSettings.Password);

            profileDecrypt.Cards = cards.JsonToObject<List<Card>>();

            profileDecrypt.FileName = profileSettings.ProfileFileName;
            return profileDecrypt;

        }


        public void Delete(string fileName)
        {
            //TODO: Colocar logica de backup files
            fileName = Path.Combine(GetBaseDiretoryFromAppConfig(), fileName);
            if(File.Exists(fileName))
            { File.Delete(fileName); }
        }
    }
}
