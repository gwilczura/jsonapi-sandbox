using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Resources;

namespace Wilczura.Common.JsonApi.Controllers;

public abstract class CustomController<TResource, TId>
    : JsonApiController<TResource, TId> where TResource : class, IIdentifiable<TId>
{
    public CustomController(CustomControllerDependencies<TResource, TId> dependencies)
        : base(dependencies.Options, dependencies.ResourceGraph, dependencies.LoggerFactory, dependencies.ResourceService)
    {
    }
}
