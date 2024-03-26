using System.Collections.Generic;
namespace Core.Utilities.Helper
{
    public static class AttributeHelper
    {
        public static List<List<int>> Permutations(List<List<int>> arrays)
        {
            List<List<int>> res = new()
            {
                new()
            };
            foreach (var list in arrays)
            {
                List<List<int>> newRes = new();
                foreach (var num in list)
                {
                    foreach (var resItem in res)
                    {
                        List<int> newResItem = new() { num };
                        newResItem.AddRange(resItem);
                        newRes.Add(newResItem);
                    }
                }
                res = newRes;
            }
            return res;
        }
    }
}