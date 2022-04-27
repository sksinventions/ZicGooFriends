namespace ZicGooFriendsWeb.Models
{
    public class UserDto
    {
        public UserModel UserInfo { get; set; } = null;
        
        public UserDto(UserModel user)
        {
            UserInfo = user;
        }

        public UserDto()
        {
            UserInfo = new UserModel();
        }
    }
}
