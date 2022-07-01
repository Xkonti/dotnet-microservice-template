using FastExpressionCompiler;
using Mapster;

namespace Service.Models;

public static class MappingProfiles
{
    /// <summary>
    /// Setup mapper and mappings
    /// </summary>
    public static void SetupMapper()
    {
        // Ignore cases: https://github.com/MapsterMapper/Mapster/wiki/Naming-convention#ignore-cases
        TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

        // Fast compilation using FastExpressionCompiler: https://github.com/MapsterMapper/Mapster/wiki/FastExpressionCompiler
        TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

        SetupMappings();
    }

    /// <summary>
    /// Place to set up mappings from one type to another.
    /// Documentation: https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping
    /// </summary>
    private static void SetupMappings()
    {
    }
}