﻿using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;

namespace Wilczura.JsonApiTest.JsonApi.Common;

public class GregResourceRepository<TResource, TId> : EntityFrameworkCoreRepository<TResource, TId>
    where TResource : class, IIdentifiable<TId>
{
    public GregResourceRepository(
        GregResourceDependencies dependencies) 
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
