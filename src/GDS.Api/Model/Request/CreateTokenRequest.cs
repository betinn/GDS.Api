using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class CreateTokenRequest
    {
        public Guid ProfileId { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string Password { get; set; }
    }
}
