using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Repository.Interface
{
    public interface ICardRepository
    {
        void Create(CreateCardRequest cardRequest, Profile profile);
        void Delete(Guid idCard, Profile profile);
        void Update(Guid idCard, UpdateCardRequest updateCardRequest, Profile profile);
    }
}
