using InMemoryCaching.Models;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCaching.Data;
public class ApiDbContext : DbContext
{
    public DbSet<Driver> Drivers { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
      : base(options)
    {
    }
}