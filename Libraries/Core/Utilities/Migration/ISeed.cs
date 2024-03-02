using Core.Utilities.Results;
using eCommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Utilities.Migration
{
    public interface ISeed<T> where T : IEntity
    {
        List<T> GetSeedData();
    }
}
