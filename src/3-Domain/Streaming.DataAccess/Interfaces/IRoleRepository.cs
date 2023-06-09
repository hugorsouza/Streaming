using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.DataAccess;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Interfaces
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }
}
