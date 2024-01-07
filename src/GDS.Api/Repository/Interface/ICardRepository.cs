using GDS.Api.Model;
using GDS.Api.Model.Request;

namespace GDS.Api.Repository.Interface
{
    public interface ICardRepository
    {
        void Create(CreateCardRequest cardRequest, Profile profile);
    }
}
