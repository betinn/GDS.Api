using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GDS.Api.Model.Request
{
    public class CreateCardRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string ImgBase64 { get; set; } = string.Empty;

    }
}
