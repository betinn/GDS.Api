using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface ICardService
    {
        Profile Create(CreateCardRequest cardRequest);
    }
}
