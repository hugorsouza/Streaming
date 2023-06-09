using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.DataAccess.EntityFramework;
using Streaming.DataAccess.Concrete.EntityFramework.Configuration;
using Streaming.DataAccess.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework
{
    public class EfRoleRepository : EfRepository<Role, ApplicationDbContext, int>, IRoleRepository
    {
    }
}
