using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Id).HasColumnName("CategoryId");
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
