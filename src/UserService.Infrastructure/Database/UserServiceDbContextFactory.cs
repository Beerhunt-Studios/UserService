using BaseChord.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserService.Infrastructure.Database;

public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
{
    public UserServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
        optionsBuilder.UseSqlServer(string.Empty);

        return new UserServiceDbContext(optionsBuilder.Options);
    }
}
