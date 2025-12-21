using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseChord.Application;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Mappings;

namespace UserService.Application;

public static class ConfigureServices
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddMappings();

        return services;
    }

    private static void AddMappings(this IServiceCollection services)
    {
        services.AddTransient<MusicGenreResolver>();
    }
}
