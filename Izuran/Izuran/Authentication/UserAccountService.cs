namespace Izuran.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;

        public UserAccountService()
        {
            _userAccountList = new List<UserAccount>
            {
                new UserAccount{UserName = "admin", Password = "admin", Id = 1},
                new UserAccount{UserName = "user", Password = "user", Id = 2}
            };
        }
        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
