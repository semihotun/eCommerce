using Core.SeedWork;
using System;

namespace Entities.Dtos.CommentDALModels
{
    public class CombinationPhotoDTO : BaseEntity
    {
        public Guid PhotoId { get; set; }
        public Guid CombinationId { get; set; }
    }
}
