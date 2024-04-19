using System;
using System.Collections.Generic;
namespace Core.Utilities.Helper
{
    public static class AttributeHelper
    {
        public static List<List<Guid>> Permutations(List<List<Guid>> arrays)
        {
            List<List<Guid>> res = new()
            {
                new()
            };
            foreach (var list in arrays)
            {
                List<List<Guid>> newRes = new();
                foreach (var num in list)
                {
                    foreach (var resItem in res)
                    {
                        List<Guid> newResItem = new() { num };
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