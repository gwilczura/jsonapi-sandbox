using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Repositories;

public class PersonResourceRepository : EntityFrameworkCoreRepository<Person, int>
{
    public PersonResourceRepository(
        ITargetedFields targetedFields, 
        IDbContextResolver dbContextResolver, 
        IResourceGraph resourceGraph, 
        IResourceFactory resourceFactory, 
        IEnumerable<IQueryConstraintProvider> constraintProviders, 
        ILoggerFactory loggerFactory, 
        IResourceDefinitionAccessor resourceDefinitionAccessor) 
        : base(targetedFields, dbContextResolver, resourceGraph, resourceFactory, constraintProviders, loggerFactory, resourceDefinitionAccessor)
    {
    }

    protected override IQueryable<Person> GetAll()
    {
        return base.GetAll();
    }

    public override Task<IReadOnlyCollection<Person>> GetAsync(QueryLayer queryLayer, CancellationToken cancellationToken)
    {
        return base.GetAsync(queryLayer, cancellationToken);
    }
}
