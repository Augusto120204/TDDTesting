// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using global::System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: global::Xunit.TestFramework("Reqnroll.xUnit.ReqnrollPlugin.XunitTestFrameworkWithAssemblyFixture", "Reqnroll.xUnit.ReqnrollPlugin")]
[assembly: global::Reqnroll.xUnit.ReqnrollPlugin.AssemblyFixture(typeof(global::Productos_XUnitAssemblyFixture))]

[GeneratedCode("Reqnroll", "2.3.0")]
public class Productos_XUnitAssemblyFixture : global::Xunit.IAsyncLifetime
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public async Task InitializeAsync()
    {
        var currentAssembly = typeof(Productos_XUnitAssemblyFixture).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunStartAsync(currentAssembly);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public async Task DisposeAsync()
    {
        var currentAssembly = typeof(Productos_XUnitAssemblyFixture).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunEndAsync(currentAssembly);
    }
}

[global::Xunit.CollectionDefinition("ReqnrollNonParallelizableFeatures", DisableParallelization = true)]
public class Productos_ReqnrollNonParallelizableFeaturesCollectionDefinition
{
}
#pragma warning restore
