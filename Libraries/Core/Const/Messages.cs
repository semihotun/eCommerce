namespace Core.Const
{
    public static class CoreMessages
    {
        public static string ThisIsNotValidationClass => "Bu bir doğrulama sınıfı değil";
        public static string WrongValidationType => "Wrong validation type.";
        public static string WrongLoggerType => "Wrong Logger Type";
        public static string NullOptionsMessage => "You have sent a blank value! Something went wrong. Please try again.";
        public static string AnUnknownErrorOccurred => "Bilinmeyen bir hata oluştu";
        public static string SimultaneousProcessing => "Simultaneous processing";
        public static string PassworIncorrect => "Parola yanlış";
        public static string InvalidToken => "Geçersiz Token";
        public static string IsAlreadyLoggedIn => "Bu kullanıcı adı zaten giriş yaptı";
        public static string JustContainLettersAZ => "Kullanıcı adı a-z A-Z harflerini içerebilir";
        public static string EmailInvalid => "Email Invalid";
        public static string UsernameAlreadyTaken => "Kullanıcı Adı Zaten alınmış";
        public static string MailAlreadyTaken => "Email zaten alınmış";
        public static string RoleAlreadyTaken => "Role zaten alınmış";
        public static string InvalidRole => "Geçersiz Rol tanımı";
        public static string AlreadyHasPasswordSet => "Kullanıcının zaten bir parola seti var";
        public static string LockoutNotEnabled => "Bu kullanıcı için kilitleme etkin değil";
        public static string WordAZ => "Parolalarda en az bir büyük harf A-Z olmalıdır";
        public static string PasswordRequiresLower => "Parolalarda en az bir küçük harf ('a'-'z') olmalıdır";
        public static string PasswordRequiresDigit => "Şifreler en az bir rakamdan oluşmalıdır ('0'-'9')";
        public static string PasswordRequiresNonAlphanumeric => "Parolalar en az bir alfasayısal olmayan karaktere sahip olmalıdır.";
        public static string UserAlreadyInRole => "Kullanıcı zaten rolde";
        public static string PasswordTooShort => "Şifre en az Bu karakter sayısı kadar olmalı";
        public static string InvalidEmail => "Email geçersiz";
    }
}
