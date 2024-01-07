namespace GDS.Api.Model.Exceptions
{
    public class BoxNotFoundException(Guid idCard, Guid idBox) : Exception
    {
        public readonly int statuscode = StatusCodes.Status404NotFound;
        public readonly string exMessage = "Box não encontrada para o idCard selecionado";
        public readonly Guid idCard = idCard;
        public readonly Guid idBox = idBox;
    }
}
