using System.Text.RegularExpressions;

namespace Wucefus.Core.Extensions
{
    public static class StringExtensions
    {
        public static string CleanWhiteSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }
    }
}
