using Domain.Entities.OrganizationEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(o => o.Category)
                .WithMany(c => c.Organizations);

            builder
                .HasMany(o => o.Tags)
                .WithMany(t => t.Organizations);
        }
    }
}
