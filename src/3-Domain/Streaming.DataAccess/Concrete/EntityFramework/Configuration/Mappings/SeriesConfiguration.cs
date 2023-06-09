using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Serie).IsUnique();

            // foreign key
            // Category(1) -> Series(n)
            builder.HasOne(x => x.Category).WithMany(c => c.Series).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id).HasColumnName("SeriesId");
            builder.Property(x => x.Actor).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.Director).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.Serie).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.Seasons).IsRequired();
            builder.Property(x => x.Streamings).IsRequired();
        }
    }
}
