using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using Microsoft.Extensions.Logging;

namespace Wilczura.Common.JsonApi.Repositories;

public class GregRepositoryDependencies
{
    public GregRepositoryDependencies(
        ITargetedFields targetedFields,
        IDbContextResolver dbContextResolver,
        IResourceGraph resourceGraph,
        IResourceFactory resourceFactory,
        IEnumerable<IQueryConstraintProvider> constraintProviders,
        ILoggerFactory loggerFactory,
        IResourceDefinitionAccessor resourceDefinitionAccessor)
    {
        TargetedFields = targetedFields;
        DbContextResolver = dbContextResolver;
        ResourceGraph = resourceGraph;
        ResourceFactory = resourceFactory;
        ConstraintProviders = constraintProviders;
        LoggerFactory = loggerFactory;
        ResourceDefinitionAccessor = resourceDefinitionAccessor;
    }

    public ITargetedFields TargetedFields { get; }
    public IDbContextResolver DbContextResolver { get; }
    public IResourceGraph ResourceGraph { get; }
    public IResourceFactory ResourceFactory { get; }
    public IEnumerable<IQueryConstraintProvider> ConstraintProviders { get; }
    public ILoggerFactory LoggerFactory { get; }
    public IResourceDefinitionAccessor ResourceDefinitionAccessor { get; }
}
