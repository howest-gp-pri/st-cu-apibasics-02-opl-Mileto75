using System.ComponentModel.DataAnnotations;

namespace Pri.Games.Api.DTOs.Request.Account
{
    public class AccountRegisterDto : AccountLoginDto
    {
        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
