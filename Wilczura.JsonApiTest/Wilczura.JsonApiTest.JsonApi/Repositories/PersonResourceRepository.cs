using JsonApiDotNetCore.Queries;
using Wilczura.JsonApiTest.Data.Entities;
using Wilczura.JsonApiTest.JsonApi.Common;

namespace Wilczura.JsonApiTest.JsonApi.Repositories;

public class PersonResourceRepository : GregResourceRepository<Person, int>
{
    public PersonResourceRepository(GregResourceDependencies dependencies) : base(dependencies)
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
