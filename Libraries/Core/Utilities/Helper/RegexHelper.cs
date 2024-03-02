using System.Text.RegularExpressions;
namespace Core.Utilities.Helper
{
    public static class RegexHelper 
    {
        public static string RemoveFromTap(string classText)
        {
            const string reduceMultiSpace = @"[ ]{2,}";
            var line = Regex.Replace(classText.Replace("\r", " "), reduceMultiSpace, " ");
            return " " + line.TrimStart();
        }
    }
}
