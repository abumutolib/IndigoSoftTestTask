using IndigoSoftTestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndigoSoftTestTask.Infrastructure.Data.Configurations;

public class UserIPConfiguration : IEntityTypeConfiguration<UserIP>
{
    public void Configure(EntityTypeBuilder<UserIP> builder)
    {
        builder.Property(e => e.IPAddress)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(e => e.IPAddress);
    }
}
