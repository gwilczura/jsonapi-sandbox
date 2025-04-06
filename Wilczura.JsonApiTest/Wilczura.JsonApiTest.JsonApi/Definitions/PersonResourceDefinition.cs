using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using Microsoft.EntityFrameworkCore.Storage;
using Wilczura.JsonApiTest.Data.Entities;
using Wilczura.JsonApiTest.Ports.Publishers;
using Wilczura.JsonApiTest.Ports.Repositories;

namespace Wilczura.JsonApiTest.JsonApi.Definitions;

public class PersonResourceDefinition : JsonApiResourceDefinition<Person, int>
{
    private readonly IDbContextResolver _dbContextResolver;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IEntityChangedPublisher _entityChangedPublisher;

    private IDbContextTransaction? _transaction;

    public PersonResourceDefinition(
        IResourceGraph resourceGraph,
        IDbContextResolver dbContextResolver,
        IOutboxRepository outboxRepository,
        IEntityChangedPublisher entityChangedPublisher) 
        : base(resourceGraph)
    {
        _dbContextResolver = dbContextResolver;
        _outboxRepository = outboxRepository;
        _entityChangedPublisher = entityChangedPublisher;
    }

    // before action on service level
    public async override Task OnPrepareWriteAsync(Person resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        await base.OnPrepareWriteAsync(resource, writeOperation, cancellationToken);
        var context = _dbContextResolver.GetContext();
        // resource definition is scoped
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    // before action on repository level
    public override Task OnWritingAsync(Person resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        return base.OnWritingAsync(resource, writeOperation, cancellationToken);
    }

    // after action on repository level
    public async override Task OnWriteSucceededAsync(Person resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_transaction);
        await base.OnWriteSucceededAsync(resource, writeOperation, cancellationToken);

        var eventName = $"{nameof(Person)}Changed";
        var entityId = resource.Id;
        var messageId = await _outboxRepository.AddMessageAsync(eventName, entityId);
        await _transaction.CommitAsync(cancellationToken);
        try
        {
            await _entityChangedPublisher.PublishEntityChangedAsync(eventName, entityId);
            await _outboxRepository.CompleteMessageAsync(messageId);
        }
        catch (Exception ex)
        {
            //TODO: log but not break
        }
    }
}
