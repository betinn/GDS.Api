namespace GDS.Api.Repository
{
    public class BaseRepository
    {

        public string GetBaseDiretoryFromAppConfig()
        {
            var keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
            if (string.IsNullOrEmpty(keys.FirstOrDefault(x => x == "DirectoryProfilePath")))
                throw new ArgumentNullException("DirectoryProfilePath", "Key não encontrada no .config");
            var dirpath = System.Configuration.ConfigurationManager.AppSettings[keys.FirstOrDefault(x => x == "DirectoryProfilePath")];
            if (!Directory.Exists(dirpath))
                throw new ArgumentException("Diretorio indicado no .config não existe", dirpath);

            return dirpath;
        }
    }
}
