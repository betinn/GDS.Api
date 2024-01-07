using GDS.Api.Model.Request;
using GDS.Api.Model;

namespace GDS.Api.Repository.Interface
{
    public interface IBoxRepository
    {
        void AddBox(Guid idcard, CreateBoxRequest boxRequest, Profile profile);
    }
}
