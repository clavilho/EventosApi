using System.Reflection;

namespace EventoGerenciador.CrossCutting.Assemblies;

public class AssemblyUtil
{
    public static IEnumerable<Assembly> GetCurrentAssemblies()
    {
        return new Assembly[]
        {
            Assembly.Load("EventoGerenciador.Api"),
            Assembly.Load("EventoGerenciador.Application"),
            Assembly.Load("EventoGerenciador.Domain"),
            Assembly.Load("EventoGerenciador.Domain.Core"),
            Assembly.Load("EventoGerenciador.Infrastructure"),
            Assembly.Load("EventoGerenciador.CrossCutting")
        };
    }
}
