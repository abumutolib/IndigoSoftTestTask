using IndigoSoftTestTask.Domain.Entities;

namespace IndigoSoftTestTask.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<UserIP> UserIPs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
