using Streaming.Core.DataAccess;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Interfaces
{
    public interface ISeriesRepository : IRepository<Series, int>
    {
    }
}
