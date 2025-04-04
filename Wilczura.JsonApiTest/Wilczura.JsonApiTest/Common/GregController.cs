using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Resources;

namespace Wilczura.JsonApiTest.Common;

public abstract class GregController<TResource, TId> 
    : JsonApiController<TResource, TId> where TResource : class, IIdentifiable<TId>
{
    public GregController(GregControllerDependencies<TResource,TId> dependencies) 
        : base(dependencies.Options, dependencies.ResourceGraph, dependencies.LoggerFactory, dependencies.ResourceService)
    {
    }
}
