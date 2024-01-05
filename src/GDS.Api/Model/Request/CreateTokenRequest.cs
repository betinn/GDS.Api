using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class CreateTokenRequest
    {
        [Required]
        public string ProfileFileName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string Password { get; set; }
    }
}
