using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface IBoxService
    {
        Profile Create(Guid idcard, CreateBoxRequest boxRequest);
        Profile Delete(Guid idCard, Guid idBox);
        Profile Update(Guid idCard, Guid idBox, CreateBoxRequest boxRequest);
    }
}
