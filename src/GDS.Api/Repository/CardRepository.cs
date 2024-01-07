using GDS.Api.Model;
using GDS.Api.Model.Exceptions;
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

        public void Delete(Guid idCard, Profile profile)
        {
            var card = profile.Cards.FirstOrDefault(x => x.Id.Equals(idCard));

            if (card == null) { throw new CardNotFoundException(idCard); }

            profile.Cards.Remove(card);
        }

        public void Update(Guid idCard, UpdateCardRequest updateCardRequest, Profile profile)
        {
            var card = profile.Cards.FirstOrDefault(x => x.Id.Equals(idCard));

            if(card == null) { throw new CardNotFoundException(idCard); }

            card.Name = updateCardRequest.Name;
            card.ImgBase64 = updateCardRequest.ImgBase64;
        }
    }
}
