using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class UpdateProfileRequest
    {
        [Required(ErrorMessage = "Propriedade 'Name' é obrigatória")]
        [Length(6, 99, ErrorMessage = "Propriedade 'Name' deve possuir de 6 a 99 caracteres")]
        public string Name { get; set; } = string.Empty;

        public string? ImgBase64 { get; set; } = string.Empty;
    }
}
