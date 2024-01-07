using GDS.Api.Model;
using GDS.Api.Model.Request;
using GDS.Api.Repository.Interface;

namespace GDS.Api.Repository
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public void Create(CreateCardRequest cardRequest, Profile profile)
        {
            profile.Cards.Add(new Card(Guid.NewGuid(),
                cardRequest.Name,
                cardRequest.ImgBase64));

            
        }
    }
}
