using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class UpdateCardRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string ImgBase64 { get; set; } = string.Empty;
    }
}
