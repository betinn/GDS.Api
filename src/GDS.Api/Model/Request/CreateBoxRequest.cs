using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class CreateBoxRequest
    {
        [Required]
        public string Name {  get; set; } = string.Empty;
        public bool IsSecret {  get; set; }
        [Required]

        public string Data { get; set; }=string.Empty;
    }
}
