using Microsoft.EntityFrameworkCore;
using TestWeb.Entities;

namespace TestWeb.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<VacationEntity> Vacations { get; set; }
}
