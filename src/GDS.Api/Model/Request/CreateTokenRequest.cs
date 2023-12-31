namespace GDS.Api.Model.Request
{
    public class CreateTokenRequest
    {
        public Guid ProfileId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
