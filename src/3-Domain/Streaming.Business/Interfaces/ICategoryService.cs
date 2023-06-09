using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Interfaces
{
    public interface ICategoryService
    {
        ICollection<Category> FindAll();
        Category FindById(int id);
        Category FindByName([NotNull] string name);
        ServiceResult Add([NotNull] Category category);
        ServiceResult Update([NotNull] Category category);
        ServiceResult RemoveById(int id);
    }
}
