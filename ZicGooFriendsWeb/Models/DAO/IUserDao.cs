namespace ZicGooFriendsWeb.Models
{
    public interface IUserDao : IDisposable
    {
        Task<List<UserModel>> DeleteUser(UserModel user);
        public Task<List<UserModel>> DeleteUserId(int uid);
        Task<List<UserModel>> GetAllUsers();
        Task<List<UserModel>> GetUserById(int uid);
        Task<List<UserModel>> GetUser(UserModel user);
        Task<List<UserModel>> GetUserByAccountPw(string account, string pw);
        Task InsertUser(UserModel user);
        public Task<List<UserModel>> UpdateUser(UserModel user);
    }
}