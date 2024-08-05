using System.Text.RegularExpressions;

namespace EMS.Utilities
{
    public static class Utils
    {
        public static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName,(current,c) => current.Replace(c.ToString(),string.Empty));
        }

        public static string CleanPathName(string fileName)
        {
            return Path.GetInvalidPathChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static string ReplaceSpecialCharacter(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            var regex = "[\x00-\x08\x0B\x0C\x0E-\x1F]";
            string replacedValue = Regex.Replace(value, regex, "", RegexOptions.Compiled);
            return replacedValue;
        }
    }
}
