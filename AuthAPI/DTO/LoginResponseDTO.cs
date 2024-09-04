using System.ComponentModel.DataAnnotations;

namespace AuthAPI.DTO
{
    public class LoginResponseDTO
    {
        public int StatusCode { get; set; }

        public string Token { get; set; } 
        public string Message { get; set; }
    }
}
