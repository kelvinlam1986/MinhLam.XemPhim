namespace MinhLam.XemPhim.Application
{
    public class ApplicationExceptionCodes
    {
        public const string UserNameIsEmpty = "username_is_empty";
        public const string PasswordIsEmpty = "password_is_empty";
        public const string UserNotFound = "user_not_found";
        public const string UserIsLocked = "user_is_locked";
        public const string PasswordNotMatched = "password_not_matched";
        public const string UserNotAdminPage = "user_not_admin_page";
        public const string UnexpectedError = "unexpected_error";
        public const string AccountNotExist = "account_not_exist";
        public const string UserRoleNotExist = "user_role_not_exist";
    }
}
