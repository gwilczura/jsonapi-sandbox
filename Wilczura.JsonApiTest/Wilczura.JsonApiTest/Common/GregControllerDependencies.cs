using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;

namespace Wilczura.JsonApiTest.Common;

public class GregControllerDependencies<TResource, TId>  where TResource : class, IIdentifiable<TId>
{
    public GregControllerDependencies(
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
