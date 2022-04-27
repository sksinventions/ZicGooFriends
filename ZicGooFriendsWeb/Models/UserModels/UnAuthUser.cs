using System.ComponentModel.DataAnnotations;

namespace ZicGooFriendsWeb.Models
{
    public class UnAuthUser
    {
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(16, ErrorMessage = "Must be in email format", MinimumLength = 8)]
        [RegularExpression(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?", ErrorMessage = "Must include more than one character, number and special letter")]
        public string AccountID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 8 and 16 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Must include more than one character, number and special letter")]
        public string Password { get; set; } = string.Empty;
    }
}
