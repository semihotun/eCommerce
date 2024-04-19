using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class ShowCase : BaseEntity, IEntity
    {
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public Guid ShowCaseType { get; set; }
        public string ShowCaseText { get; set; }
    }
}
