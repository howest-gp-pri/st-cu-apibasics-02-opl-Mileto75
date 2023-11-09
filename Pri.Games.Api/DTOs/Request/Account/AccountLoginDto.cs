using System.ComponentModel.DataAnnotations;

namespace Pri.Games.Api.DTOs.Request.Account
{
    public class AccountLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
