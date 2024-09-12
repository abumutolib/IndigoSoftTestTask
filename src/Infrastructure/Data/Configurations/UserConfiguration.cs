using Microsoft.EntityFrameworkCore;
using IndigoSoftTestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndigoSoftTestTask.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(e => e.UserIPs)
            .WithOne(e => e.User)
            .HasPrincipalKey(e => e.Id)
            .HasForeignKey(e => e.UserId);
    }
}
