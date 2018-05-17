using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Wucefus.Core.Extensions
{
    public static class Extensions
    {
        public static string CleanWhiteSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }

        public static string Serialize<T>(this T instance)
        {
            string result = string.Empty;

            if (instance != null)
            {
                result = JsonConvert.SerializeObject(instance,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }

            return result;
        }
    }
}
