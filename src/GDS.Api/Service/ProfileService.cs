using GDS.Api.Model;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using GDS.Api.Util;
using System.Security.Cryptography;
using System.Text;

namespace GDS.Api.Service
{
    public class ProfileService() : IProfileService
    {
        private readonly string _extension = ".gdsprofile";
        public List<string> ListProfilesFromBaseDiretory()
        {
            return Directory.GetFiles(GetBaseDiretoryFromAppConfig()).ToList();
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



            Profile profile = new Profile(request.Name);
            profile.Cards.Add(exemploCard);

            ProfileEncrypted profileEncrypted =
                new ProfileEncrypted(
                profile.Name,
                profile.ImgBase64,
                Criptography.EncryptStringToBytes_Aes(
                    profile.Cards.ToJson(),
                    request.User, //user e password precisam ter lengh iguais para funcionar.
                    request.Password)
                );


            var baseDir = GetBaseDiretoryFromAppConfig();

            if( !Directory.Exists(baseDir) ) {  Directory.CreateDirectory(baseDir); }

            var fileToCreate = Path.Combine(baseDir,
                string.Format("{0}_{1}{2}", 
                profileEncrypted.Name, 
                Guid.NewGuid(), 
                _extension));

            File.WriteAllText(fileToCreate, profileEncrypted.ToJson());
        }


        #region private methods
        
        private string GetBaseDiretoryFromAppConfig()
        {
            var keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
            if (string.IsNullOrEmpty(keys.FirstOrDefault(x => x == "DirectoryProfilePath")))
                throw new ArgumentNullException("DirectoryProfilePath", "Key não encontrada no .config");
            var dirpath = System.Configuration.ConfigurationManager.AppSettings[keys.FirstOrDefault(x => x == "DirectoryProfilePath")];
            if (!Directory.Exists(dirpath))
                throw new ArgumentException("Diretorio indicado no .config não existe", dirpath);

            return dirpath;
        }

        #endregion
    }
}
