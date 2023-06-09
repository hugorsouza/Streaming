using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Interfaces
{
    public interface ISeriesService
    {
        ICollection<Series> FindAll();
        ICollection<Series> FindAllByCategoryId(int categoryId);
        Series FindById(int id);
        Series FindBySeries([NotNull] string name);
        ServiceResult Add([NotNull] Series Series);
        ServiceResult Update([NotNull] Series Series);
        ServiceResult RemoveById(int id);
    }
}