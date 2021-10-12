namespace MinhLam.XemPhim.Domain
{
    public static class DomainExceptionCodes
    {
        public const string UsernameIsBlank = "username_is_blank";
        public const string PasswordIsBlank = "password_is_blank";
        public const string PasswordIsNotValidFormat = "password_is_not_valid_format";
        public const string AccountNameIsBlank = "account_name_is_blank";
        public const string EmailIsBlank = "email_is_blank";
        public const string EmailIsNotValidFormat = "email_is_not_valid_Format";
        public const string PhoneIsBlank = "phone_is_blank";
        public const string AccountExistWithUserName = "account_exist_with_username";
        public const string AccountExistWithEmail = "account_exist_with_email";
        public const string AccountGroupNotExist = "account_group_not_exist";
        public const string AccountNotExist = "account_not_exist";
        public const string UserRoleNotExist = "user_role_not_exist";
        public const string UserRoleAlreadyExistInAccount = "user_role_already_exist_in_account";
    }
}
