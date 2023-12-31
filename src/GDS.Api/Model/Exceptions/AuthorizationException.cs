namespace GDS.Api.Model.Exceptions
{
    public class AuthorizationException : Exception
    {
        public readonly int statuscode = StatusCodes.Status401Unauthorized;
        public readonly string exMessage = "Não autenticado";
        public AuthorizationException() { }
    }
}
