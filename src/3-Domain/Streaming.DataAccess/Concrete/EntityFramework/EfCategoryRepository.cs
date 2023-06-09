using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Streaming.Core.DataAccess.EntityFramework;
using Streaming.DataAccess.Concrete.EntityFramework.Configuration;
using Streaming.DataAccess.Interfaces;
using Streaming.Entities.Concrete;
using Streaming.Entities.DTOs.Category;

namespace Streaming.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfRepository<Category, ApplicationDbContext, int>, ICategoryRepository
    {
        public CategoryCheckChildExist CheckChildExist(Expression<Func<Category, bool>> predicate)
        {
            using var context = new ApplicationDbContext();
            return context.Categories.Where(predicate)
                .Include(x => x.Movies)
                .Include(x=> x.Series)
                .Select(x => new CategoryCheckChildExist
                {
                    IsMoviesExist = x.Movies.Any(), 
                    IsSeriesExist = x.Series.Any()
                }).FirstOrDefault();
        }
    }
}
