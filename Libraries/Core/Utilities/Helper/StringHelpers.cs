using System;
using System.Globalization;
using System.Text.RegularExpressions;
namespace Core.Utilities.Helper
{
    public static class StringHelpers
    {
        public static string UrlFormatConverter(string name)
        {
            return name.ToLower().Replace("'", "")
            .Replace(" ", "-")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("&", "")
            .Replace("[", "")
            .Replace("!", "")
            .Replace("]", "")
            .Replace("ı", "i")
            .Replace("ö", "o")
            .Replace("ü", "u")
            .Replace("ş", "s")
            .Replace("ç", "c")
            .Replace("ğ", "g")
            .Replace("İ", "I")
            .Replace("Ö", "O")
            .Replace("Ü", "U")
            .Replace("Ş", "S")
            .Replace("Ç", "C")
            .Replace("Ğ", "G")
            .Replace("|", "")
            .Replace(".", "-")
            .Replace("?", "-")
            .Replace(";", "-")
            .Replace("#", "-sharp");
        }
        public static string Capitilize(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var result = string.Empty;
            foreach (var item in text.Split(' '))
            {
                if (item.Length > 1)
                    result += $"{item[..1].ToUpper()}{item[1..].ToLower()} ";
                else
                    result += $"{item} ";
            }
            return result.Trim();
        }
        public static string GetCode() =>
            Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "").ToLower(new CultureInfo("en-US", false));
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;
            return char.ToLower(str[0]) + str[1..];
        }
    }
}
