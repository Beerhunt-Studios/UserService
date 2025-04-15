using AutoMapper;
using UserService.Application.Interfaces.Repositories;
using Xunit;

namespace UserService.Application.Tests;

public class MappingTest
{
    [Fact]
    public static void TestMapping()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AssemblyDefinition).Assembly));

        configuration.AssertConfigurationIsValid();
    }


}
