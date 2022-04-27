using System.ComponentModel.DataAnnotations;

namespace ZicGooFriendsWeb.Models
{
    public class UserModel
    {
        public int uid;

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(16, ErrorMessage = "Must be in email format", MinimumLength = 8)]
        [RegularExpression(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?", ErrorMessage = "Must include more than one character, number and special letter")]
        public string AccountID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nick name is required")]
        public string NickName { get; set; } = string.Empty;
        public string KorName { get; set; } = string.Empty;
        [Required(ErrorMessage = "English Name is required")]
        public string EngName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 8 and 16 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Must include more than one character, number and special letter")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile phone number is required")]
        public string MobilePhoneNum { get; set; } = string.Empty;
        public string TelephoneNum { get; set; } = string.Empty;

        [Required(ErrorMessage = "PCCC is required")]
        public string PCCC { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Post Office Box is required")]
        public string PostOfficeBox { get; set; } = string.Empty;
        [Required(ErrorMessage = "ZIP code is required")]
        public string ZIPcode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Main address is required")]
        public string MainAddress { get; set; } = string.Empty;
        public string SubAddress { get; set; } = string.Empty;

        public bool IsAutoPayMode { get; set; } = false;
        public double AutoPayLimit { get; set; } = 0.0;

        public DateTime RegisterDateTime { get; set; }
        public DateTime LastLoginDateTime { get; set; }

        public string Role { get; set;} = "Standard";
    }
}
