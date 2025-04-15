using System.Reflection;
using BaseChord.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Database;

public class UserServiceDbContext : DbContext
{
    public const string Schema = "UserService";

    public UserServiceDbContext() : base()
    {

    }

    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddInfrastructure(typeof(UserServiceDbContext).Assembly);
    }
}
