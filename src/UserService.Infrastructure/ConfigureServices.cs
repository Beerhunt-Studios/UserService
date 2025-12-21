using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BaseChord.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application;
using UserService.Application.Interfaces.Repositories;
using UserService.Infrastructure.Database;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices<UserServiceDbContext, EventbusDbContext>(configuration, UserServiceDbContext.Schema, typeof(UserServiceDbContext).Assembly, typeof(AssemblyDefinition).Assembly);
        services.AddRepositories();

        return services;
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserInformationRepository, UserInformationRepository>();
        services.AddTransient<IMusicGenreRepository, MusicGenreRepository>();
    }
}
