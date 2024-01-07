using GDS.Api.Model.Exceptions;
using GDS.Api.Model.Request;
using GDS.Api.Model;
using GDS.Api.Service.Interface;
using GDS.Api.Service;
using GDS.Api.Repository.Interface;

namespace GDS.Api.Repository
{
    public class BoxRepository(IAuthService authService) : BaseRepository, IBoxRepository
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

    }
}
