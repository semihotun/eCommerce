using Microsoft.AspNetCore.Mvc;

namespace Plugin.Base
{
    public interface IPlugin
    {
        string Name { get; }
        string GetContentUrl(IUrlHelper urlHelper);
        string GetSettingsUrl(IUrlHelper urlHelper);
    }
}
