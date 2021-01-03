
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string  UserName { get; set; }

        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Password Must be 4 to 8 Digit Long")]
        public string Password { get; set; }
    }
}