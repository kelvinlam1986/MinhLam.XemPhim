namespace MinhLam.XemPhim.Application.Commands
{
    public class LoginCommand
    {
        public LoginCommand(string username, string password, bool loginInAdminPage)
        {
            this.Username = username;
            this.Password = password;
            this.LoginInAdminPage = loginInAdminPage;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoginInAdminPage { get; set; }
    }
}
