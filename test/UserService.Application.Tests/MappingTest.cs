using AutoMapper;
using BaseChord.Application;
using UserService.Application.Interfaces.Repositories;
using Xunit;

namespace UserService.Application.Tests;

public class MappingTest
{
    [Fact]
    public static void TestMapping()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddIMapConfiguration(typeof(AssemblyDefinition).Assembly));

        configuration.AssertConfigurationIsValid();
    }


}
