using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class AuthProfileRequest
    {
        [Required]
        public string ProfileFilePath { get; set; } = string.Empty;
        [Required]
        public string User { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
