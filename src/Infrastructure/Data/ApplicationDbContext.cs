using System.Reflection;
using Microsoft.EntityFrameworkCore;
using IndigoSoftTestTask.Domain.Entities;
using IndigoSoftTestTask.Application.Common.Interfaces;

namespace IndigoSoftTestTask.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users => Set<User>();
    
    public DbSet<UserIP> UserIPs => Set<UserIP>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
