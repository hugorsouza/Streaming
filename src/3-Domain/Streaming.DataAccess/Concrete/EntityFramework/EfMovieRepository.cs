using Streaming.Core.DataAccess.EntityFramework;
using Streaming.DataAccess.Concrete.EntityFramework.Configuration;
using Streaming.DataAccess.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework
{
    public class EfMoviesRepository : EfRepository<Movies, ApplicationDbContext, int>, IMoviesRepository
    {
    }
}
