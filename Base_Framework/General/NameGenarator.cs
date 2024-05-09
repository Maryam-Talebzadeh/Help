

namespace Base_Framework.General
{
    public class NameGenarator
    {
        public static string GenerateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
