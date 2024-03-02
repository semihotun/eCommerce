using eCommerce.Core.Entities;
using System.Collections.Generic;
namespace Core.Utilities.Migration
{
    public interface ISeed<T> where T : IEntity
    {
        List<T> GetSeedData();
    }
}
