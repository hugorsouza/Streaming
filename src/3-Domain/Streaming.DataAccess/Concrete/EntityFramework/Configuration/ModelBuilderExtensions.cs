using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializer;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration
{
    static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            new DbInitializer().Seed(modelBuilder);
        }
    }
}
