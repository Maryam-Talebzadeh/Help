﻿

namespace Base_Framework.Domain.Services
{
    public class ValidationMessages
    {
        public const string IsRequired = "این مقدار نمی تواند خالی باشد";
        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";
        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
        public const string MaxLenght = "مقدار وارد شده بیش از طول مجاز است";
        public const string WrongRePassword = "تکرار رمز عبور با رمز عبور مغایرت دارد";
    }
}
