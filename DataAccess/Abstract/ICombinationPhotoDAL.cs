using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTO;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{

    public interface ICombinationPhotoDAL : IEntityRepository<CombinationPhoto>
    {
        IDataResult<List<CombinationPhotoDTO>> GetAllCombinationPhotos(int productId, int photoId);
    }


}
