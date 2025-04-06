using JsonApiDotNetCore.Repositories;
using Wilczura.JsonApiTest.Ports.Repositories;

namespace Wilczura.JsonApiTest.JsonApi.Common;

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
