using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;

namespace Wilczura.Common.JsonApi.Repositories;

public class CustomResourceRepository<TResource, TId> : EntityFrameworkCoreRepository<TResource, TId>
    where TResource : class, IIdentifiable<TId>
{
    public CustomResourceRepository(
        CustomResourceRepositoryDependencies dependencies)
        : base(dependencies.TargetedFields,
            dependencies.DbContextResolver,
            dependencies.ResourceGraph,
            dependencies.ResourceFactory,
            dependencies.ConstraintProviders,
            dependencies.LoggerFactory,
            dependencies.ResourceDefinitionAccessor)
    {
    }
}
