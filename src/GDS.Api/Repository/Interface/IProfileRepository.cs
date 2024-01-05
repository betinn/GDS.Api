using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Repository.Interface
{
    public interface IProfileRepository
    {
        public Profile AddBox(Guid idcard, CreateBoxRequest boxRequest);
        string GetBaseDiretoryFromAppConfig();
    }
}
