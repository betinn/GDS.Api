using GDS.Api.Service.Interface;

namespace GDS.Api.Service
{
    public class ProfileService() : IProfileService
    {

        public List<string> ListProfilesFromBaseDiretory()
        {
            var keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
            if (string.IsNullOrEmpty(keys.FirstOrDefault(x => x == "DirectoryProfilePath")))
                throw new ArgumentNullException("DirectoryProfilePath", "Key não encontrada no .config");
            var dirpath = System.Configuration.ConfigurationManager.AppSettings[keys.FirstOrDefault(x => x == "DirectoryProfilePath")];
            if (!Directory.Exists(dirpath))
                throw new ArgumentException("Diretorio indicado no .config não existe", dirpath);

            return Directory.GetFiles(dirpath).ToList();
        }
    }
}
