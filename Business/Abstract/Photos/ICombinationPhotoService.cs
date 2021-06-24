using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Photos
{
    public interface ICombinationPhotoService
    {
       Task<IDataResult<List<CombinationPhoto>>> GetAllCombinationPhotos(int productId = 0, int photoId = 0);

        Task<IResult> InsertCombinationPhotos(int photoId, string combinations = "", string notCombinations = "");
    }
}
