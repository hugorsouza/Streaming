using System.Collections.Generic;
using Streaming.Core.Entities;

namespace Streaming.Entities.Concrete
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
