namespace ZicGooFriendsWeb.Models
{
    public class User
    {
        public string AccountID { get; set; } = string.Empty;

        public string NickName { get; set; } = string.Empty;
        public string KorName { get; set; } = string.Empty;
        public string EngName { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public string MobilePhoneNum { get; set; } = string.Empty;
        public string TelephoneNum { get; set; } = string.Empty;

        public string PCCC { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PostOfficeBox { get; set; } = string.Empty;
        public string ZIPcode { get; set; } = string.Empty;
        public string MainAddress { get; set; } = string.Empty;
        public string SubAddress { get; set; } = string.Empty;

        public bool IsAutoPayMode { get; set; }
        public double AutoPayLimit { get; set; } = 0.0;

        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
