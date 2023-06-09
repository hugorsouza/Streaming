using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Id).HasColumnName("RoleId");
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
