using DataAccessLibrary.DataAccess;

namespace ZicGooFriendsWeb.Models
{
    public class UserDao : IUserDao
    {
        private readonly ISqlDataAccess _db;
        private bool isDisposed = false;

        public UserDao(ISqlDataAccess db)
        {
            _db = db;
        }

        #region Get
        public Task<List<UserModel>> GetAllUsers()
        {
            string sql = "SELECT * FROM users";
            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public Task<List<UserModel>> GetUser(UserModel user)
        {
            string sql = "SELECT * FROM users WHERE account_id=@account_id AND password=@password";
            return _db.LoadData<UserModel, dynamic>(sql, new { account_id = user.AccountID, password = user.Password });
        }

        public Task<List<UserModel>> GetUserById(int uid)
        {
            string sql = "SELECT * FROM users WHERE uid=@uid";
            return _db.LoadData<UserModel, dynamic>(sql, new { uid = uid });
        }

        public Task<List<UserModel>> GetUserByAccountPw(string account, string pw)
        {
            string sql = "SELECT * FROM users WHERE account_id=@account_id AND password=@password";
            return _db.LoadData<UserModel, dynamic>(sql, new { account_id = account, password = pw });
        }
        #endregion

        #region Insert
        public Task InsertUser(UserModel user)
        {
            string sql = @"INSERT INTO users (account_id, nickname,korname,engname,password,mobilephone_num,telephone_num,pccc,email,postofficebox,zip_code,main_address,sub_address,is_autopay_mode,autopay_limit)" +
                @"values (@account_id,@nickname,@korname,@engname,@password,@mobilephone_num,@telephone_num,@pccc,@email,@postofficebox,@zip_code,@main_address,@sub_address,@is_autopay_mode,@autopay_limit)";
            return _db.SaveData(sql, new {
                account_id = user.AccountID,
                nickname= user.NickName,
                korname = user.KorName,
                engname=user.EngName,
                password = user.Password,
                mobilephone_num = user.MobilePhoneNum,
                telephone_num = user.TelephoneNum,
                pccc = user.PCCC,
                email = user.Email,
                postofficebox = user.PostOfficeBox,
                zip_code = user.ZIPcode,
                main_address = user.MainAddress,
                sub_address = user.SubAddress,
                is_autopay_mode = user.IsAutoPayMode,
                autopay_limit = user.AutoPayLimit
            });
        }
        #endregion

        #region Update
        public Task<List<UserModel>> UpdateUser(UserModel user)
        {
            string sql = "UPDATE users SET AccountID=@AccountID, NickName=@NickName, KorName=@KorName, EngName=@EngName, " +
                "Password=@Password, MobilePhoneNum=@MobilePhoneNum, TelephoneNum=@TelephoneNum, PCCC=@PCCC, Email=@Email, " +
                "PostOfficeBox=@PostOfficeBox, ZIPcode=@ZIPcode, MainAddress=@MainAddress, SubAddress=@SubAddress, " +
                "IsAutoPayMode=@IsAutoPayMode, AutoPayLimit=@AutoPayLimit " +
                "WHERE uid=@uid";
            return _db.LoadData<UserModel, dynamic>(sql, new
            {
                AccountID = user.AccountID,
                NickName = user.NickName,
                KorName = user.KorName,
                EngName = user.EngName,
                Password = user.Password,
                MobilePhoneNum = user.MobilePhoneNum,
                TelephoneNum = user.TelephoneNum,
                PCCC = user.PCCC,
                Email = user.Email,
                PostOfficeBox = user.PostOfficeBox,
                ZIPcode = user.ZIPcode,
                MainAddress = user.MainAddress,
                SubAddress = user.SubAddress,
                IsAutoPayMode = user.IsAutoPayMode,
                AutoPayLimit = user.AutoPayLimit
            });
        }
        #endregion


        #region Delete
        public Task<List<UserModel>> DeleteUser(UserModel user)
        {
            string sql = "DELETE FROM users WHERE uid=@uid";
            return _db.LoadData<UserModel, dynamic>(sql, new
            {
                uid = user.uid
            });
        }

        public Task<List<UserModel>> DeleteUserId(int uid)
        {
            string sql = "DELETE FROM users WHERE uid=@uid";
            return _db.LoadData<UserModel, dynamic>(sql, new
            {
                uid = uid
            });
        }
        #endregion


        public virtual void Dispose()
        {
            //log connection dispose
        }
    }
}
