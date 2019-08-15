namespace FS3X.Lib
{
    internal static class Extensions
    {
        public static bool TryParse(this string @string, out int @number)
        {
            number = -1;

            if (string.IsNullOrEmpty(@string)) return false;

            @string = @string.Trim();

            if (int.TryParse(@string, out int result))
            {
                number = result;
                return true;
            }

            return false;
        }
    }
}
