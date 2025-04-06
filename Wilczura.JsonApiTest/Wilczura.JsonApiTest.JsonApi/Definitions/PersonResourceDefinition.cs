using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Repositories;
using Wilczura.Common.JsonApi.ResourceDefinitions;
using Wilczura.Common.Ports.Publishers;
using Wilczura.Common.Ports.Repositories;
using Wilczura.JsonApiTest.Adapters.Postgres.Entities;

namespace Wilczura.JsonApiTest.JsonApi.Definitions;

public class PersonResourceDefinition : DefaultOutboxResourceDefinition<Person>
{

    public PersonResourceDefinition(
        IResourceGraph resourceGraph,
        IDbContextResolver dbContextResolver,
        IOutboxRepository outboxRepository,
        IEntityChangedPublisher entityChangedPublisher) 
        : base(resourceGraph, dbContextResolver, outboxRepository, entityChangedPublisher)
    {
    }
}
