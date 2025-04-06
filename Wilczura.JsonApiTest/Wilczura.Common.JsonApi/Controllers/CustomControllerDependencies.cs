using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace Wilczura.Common.JsonApi.Controllers;

public class CustomControllerDependencies<TResource, TId> where TResource : class, IIdentifiable<TId>
{
    public CustomControllerDependencies(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceService<TResource, TId> resourceService)
    {
        Options = options;
        ResourceGraph = resourceGraph;
        LoggerFactory = loggerFactory;
        ResourceService = resourceService;
    }

    public IJsonApiOptions Options { get; }
    public IResourceGraph ResourceGraph { get; }
    public ILoggerFactory LoggerFactory { get; }
    public IResourceService<TResource, TId> ResourceService { get; }
}
