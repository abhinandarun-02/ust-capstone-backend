using System.ComponentModel.DataAnnotations;

namespace AuthAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
