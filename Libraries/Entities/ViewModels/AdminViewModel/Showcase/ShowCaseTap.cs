using System.Collections.Generic;

namespace Entities.ViewModels.AdminViewModel.Showcase
{
    public static class ShowCaseTap
    {
        public static readonly Dictionary<int, string> ShowCaseDictionary = new()
        {
            { (int)ShowcaseTapList.ShowCaseInfo, "tap1" },
            { (int)ShowcaseTapList.ShowCaseText, "tap2" },
            { (int)ShowcaseTapList.ShowCaseProductList, "tap3" },
            { (int)ShowcaseTapList.ShowCaseAddedProductList, "tap4" },
        };
    }
}
