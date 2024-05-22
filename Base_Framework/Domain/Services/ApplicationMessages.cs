

namespace Base_Framework.Domain.Services
{
    public class ApplicationMessages
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد. لطفا مجدد تلاش بفرمایید.";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش بفرمایید.";
        public const string CreationFailed = "عملیات ساخت به شکست انجامید.";
        public static string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
        public static string WrongUserName = "نام کاربری اشتباه است.";
        public static string WrongPassword = "کلمه عبور اشتباه است.";
    }
}
