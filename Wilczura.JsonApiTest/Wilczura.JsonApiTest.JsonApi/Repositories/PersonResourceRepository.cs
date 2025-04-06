using JsonApiDotNetCore.Queries;
using Wilczura.Common.JsonApi.Repositories;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.JsonApi.Repositories;

public class PersonResourceRepository : GregResourceRepository<Person, int>
{
    public PersonResourceRepository(GregRepositoryDependencies dependencies) : base(dependencies)
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
