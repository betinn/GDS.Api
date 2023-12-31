namespace GDS.Api.Model.Configuration
{
    public record class JwtSection(string Issuer,
    string Audience,
    string SigningKey,
    int ExpirationMinutes);
}
