using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Helpers
{
    public class Attributehelper
    {
        public List<List<int>> Permutations(List<List<int>> arrays)
        {

            List<List<int>> res = new List<List<int>>();
            res.Add(new List<int>());
            foreach (var list in arrays)
            {
                List<List<int>> newRes = new List<List<int>>();
                foreach (var num in list)
                {
                    foreach (var resItem in res)
                    {
                        List<int> newResItem = new List<int>() { num };
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