using BaseChord.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Database;

public class EventbusDbContext : DbContext
{

    public EventbusDbContext() : base()
    {

    }

    public EventbusDbContext(DbContextOptions<EventbusDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEventbusInfrastructure();
    }
}
