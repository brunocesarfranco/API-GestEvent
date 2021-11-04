using System;

namespace Gestevent.Core.Models
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}
