using System.Collections.Generic;
using System.Linq;
namespace Entities.ViewModels.WebViewModel.IdentityModel
{
    public static class LegacyCookieExtensions
    {
        public static IDictionary<string, string> FromLegacyCookieString(this string legacyCookie)
        {
            if (legacyCookie == null)
                return null;
            return legacyCookie.Split('&').Select(s => s.Split('=')).ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }
        public static string ToLegacyCookieString(this IDictionary<string, string> dict)
        {
            if (dict == null)
                return null;
            return string.Join("&", dict.Select(kvp => string.Join("=", kvp.Key, kvp.Value)));
        }
    }
}
