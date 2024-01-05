namespace GDS.Api.Model.Request
{
    public class CreateBoxRequest
    {
        public string Name {  get; set; } = string.Empty;
        public bool IsSecret {  get; set; }
        public string Data { get; set; }=string.Empty;
    }
}
