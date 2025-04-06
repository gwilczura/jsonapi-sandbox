using JsonApiDotNetCore.Repositories;
using Wilczura.Common.Ports.Repositories;

namespace Wilczura.Common.JsonApi.Repositories;

public class DbContextProvider : IDbContextProvider
{
    private readonly IDbContextResolver _resolver;

    public DbContextProvider(IDbContextResolver resolver)
    {
        _resolver = resolver;
    }

    public object GetContext()
    {
        return _resolver.GetContext();
    }
}
