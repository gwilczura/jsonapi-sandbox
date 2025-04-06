using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using Wilczura.JsonApiTest.Adapters.Postgres.Entities;

namespace Wilczura.JsonApiTest.JsonApi.Services;

public class PersonResourceService : JsonApiResourceService<Person, int>
{
    public PersonResourceService(
        IResourceRepositoryAccessor repositoryAccessor,
        IQueryLayerComposer queryLayerComposer,
        IPaginationContext paginationContext,
        IJsonApiOptions options,
        ILoggerFactory loggerFactory,
        IJsonApiRequest request,
        IResourceChangeTracker<Person> resourceChangeTracker,
        IResourceDefinitionAccessor resourceDefinitionAccessor)
        : base(repositoryAccessor, queryLayerComposer, paginationContext, options, loggerFactory, request, resourceChangeTracker, resourceDefinitionAccessor)
    {
    }

    public override Task<IReadOnlyCollection<Person>> GetAsync(CancellationToken cancellationToken)
    {
        return base.GetAsync(cancellationToken);
    }

    public override Task<Person> GetAsync([DisallowNull] int id, CancellationToken cancellationToken)
    {
        return base.GetAsync(id, cancellationToken);
    }

    public override Task<Person?> CreateAsync(Person resource, CancellationToken cancellationToken)
    {
        return base.CreateAsync(resource, cancellationToken);
    }

    public override Task<Person?> UpdateAsync([DisallowNull] int id, Person resource, CancellationToken cancellationToken)
    {
        return base.UpdateAsync(id, resource, cancellationToken);
    }

    public override Task DeleteAsync([DisallowNull] int id, CancellationToken cancellationToken)
    {
        return base.DeleteAsync(id, cancellationToken);
    }

    public override Task AddToToManyRelationshipAsync([DisallowNull] int leftId, string relationshipName, ISet<IIdentifiable> rightResourceIds, CancellationToken cancellationToken)
    {
        return base.AddToToManyRelationshipAsync(leftId, relationshipName, rightResourceIds, cancellationToken);
    }

    public override Task SetRelationshipAsync([DisallowNull] int leftId, string relationshipName, object? rightValue, CancellationToken cancellationToken)
    {
        return base.SetRelationshipAsync(leftId, relationshipName, rightValue, cancellationToken);
    }

    public override Task RemoveFromToManyRelationshipAsync([DisallowNull] int leftId, string relationshipName, ISet<IIdentifiable> rightResourceIds, CancellationToken cancellationToken)
    {
        return base.RemoveFromToManyRelationshipAsync(leftId, relationshipName, rightResourceIds, cancellationToken);
    } 
}
