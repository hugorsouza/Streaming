﻿using Streaming.Core.Entities;

namespace Streaming.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
