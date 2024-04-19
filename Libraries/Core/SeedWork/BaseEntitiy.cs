using System;

namespace Core.SeedWork
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
