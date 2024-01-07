namespace GDS.Api.Model.Exceptions
{
    public class CardNotFoundException(Guid id) : Exception
    {
        public readonly int statuscode = StatusCodes.Status404NotFound;
        public readonly string exMessage = "Card não encontrado";
        public readonly Guid id = id;
    }
}
