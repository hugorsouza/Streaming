using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.DataAccess;
using Streaming.Entities.Concrete;
using Streaming.Entities.DTOs.Category;

namespace Streaming.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        CategoryCheckChildExist CheckChildExist(Expression<Func<Category, bool>> predicate);
    }
}
