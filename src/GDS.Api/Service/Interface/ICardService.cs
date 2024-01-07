using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Service.Interface
{
    public interface ICardService
    {
        Profile Create(CreateCardRequest cardRequest);
        Profile Delete(Guid idCard);
        Profile Update(Guid idCard, UpdateCardRequest updateCardRequest);
    }
}
