using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using Microsoft.EntityFrameworkCore.Storage;
using Wilczura.Common.Ports.Publishers;
using Wilczura.Common.Ports.Repositories;

namespace Wilczura.Common.JsonApi.ResourceDefinitions;
/// <summary>
/// Its default because it has int already set up. Maybe in future there will be generic implementation with TId.
/// </summary>
/// <typeparam name="TResource"></typeparam>
public class DefaultOutboxResourceDefinition<TResource> : JsonApiResourceDefinition<TResource, int>
    where TResource : class, IIdentifiable<int>
{
    private readonly IDbContextResolver _dbContextResolver;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IEntityChangedPublisher _entityChangedPublisher;

    private IDbContextTransaction? _transaction;

    public DefaultOutboxResourceDefinition(
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
    public async override Task OnPrepareWriteAsync(TResource resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        await base.OnPrepareWriteAsync(resource, writeOperation, cancellationToken);
        var context = _dbContextResolver.GetContext();
        // resource definition is scoped
        // TODO: what happens if there is exception? is transaction immediately cancelled?
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    // before action on repository level
    public override Task OnWritingAsync(TResource resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        return base.OnWritingAsync(resource, writeOperation, cancellationToken);
    }

    // after action on repository level
    public async override Task OnWriteSucceededAsync(TResource resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_transaction);
        await base.OnWriteSucceededAsync(resource, writeOperation, cancellationToken);

        //TODO: typeof(T) performance?
        var eventName = $"{typeof(TResource).Name}Changed";
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
