using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class MoviesConfiguration : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.ToTable("Movies");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Movie).IsUnique();

            // foreign key
            // Category(1) -> Movies(n)
            builder.HasOne(x => x.Category).WithMany(c => c.Movies).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id).HasColumnName("MoviesId");
            builder.Property(x => x.Actor).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.Director).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.Movie).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.RunningTime).IsRequired();
        }
    }
}
