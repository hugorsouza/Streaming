using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Interfaces
{
    public interface IMovieservice
    {
        ICollection<Movies> FindAll();
        ICollection<Movies> FindAllByCategoryId(int categoryId);
        Movies FindById(int id);
        Movies FindByMovies([NotNull] string name);
        ServiceResult Add([NotNull] Movies Movies);
        ServiceResult Update([NotNull] Movies Movies);
        ServiceResult RemoveById(int id);
    }
}
