using GDS.Api.Model.Exceptions;
using GDS.Api.Model.Request;
using GDS.Api.Model;
using GDS.Api.Service.Interface;
using GDS.Api.Service;
using GDS.Api.Repository.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GDS.Api.Repository
{
    public class BoxRepository() : BaseRepository, IBoxRepository
    {

        public void AddBox(Guid idcard, CreateBoxRequest boxRequest, Profile profile)
        {
            

            var card = profile.Cards.Find(x => x.Id == idcard);
            if (card == null)
                throw new CardNotFoundException(idcard);

            card.Boxes.Add(
                new Box(
                    Guid.NewGuid(),
                    boxRequest.Name,
                    boxRequest.IsSecret,
                    boxRequest.Data
                ));

        }

        public void Delete(Guid idCard, Guid idBox, Profile profile)
        {
            var card = profile.Cards.Find(x => x.Id == idCard);
            if (card == null)
                throw new CardNotFoundException(idCard);

            var box = card.Boxes.Find(x => x.Id == idBox);
            if (box == null)
                throw new BoxNotFoundException(idCard, idBox);

            card.Boxes.Remove(box);
        }

        public void Update(Guid idCard, Guid idBox, CreateBoxRequest boxRequest, Profile profile)
        {
            var card = profile.Cards.Find(x => x.Id == idCard);
            if (card == null)
                throw new CardNotFoundException(idCard);

            var box = card.Boxes.Find(x => x.Id == idBox);
            if (box == null)
                throw new BoxNotFoundException(idCard, idBox);

            box.IsSecret = boxRequest.IsSecret;
            box.Data = boxRequest.Data;
            box.Name = boxRequest.Name;
        }
    }
}
