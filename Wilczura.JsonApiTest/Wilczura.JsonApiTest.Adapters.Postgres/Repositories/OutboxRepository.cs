using Microsoft.EntityFrameworkCore;
using Wilczura.Common.Ports.Repositories;
using Wilczura.JsonApiTest.Adapters.Postgres.Entities;

namespace Wilczura.JsonApiTest.Adapters.Postgres.Repositories;

public class OutboxRepository : IOutboxRepository
{
    private readonly TestDbContext _context;
    public OutboxRepository(IDbContextProvider dbContextProvider)
    {
        if (dbContextProvider.GetContext() is not TestDbContext context)
        {
            throw new Exception("TestDbContext is null");
        }

        _context = context;
    }

    public async Task<long> AddMessageAsync(string eventName, int entityId)
    {
        var message = new OutboxMessage
        {
            EventName = eventName,
            EntityId = entityId,
            CreatedOn = DateTimeOffset.UtcNow,
            UpdatedOn = DateTimeOffset.UtcNow,
        };

        _context.OutboxMessages.Add(message);
        await _context.SaveChangesAsync();
        return message.OutboxMessageId;
    }

    public async Task CompleteMessageAsync(long messageId)
    {
        var entity = await _context.OutboxMessages.Where(a => a.OutboxMessageId == messageId).SingleAsync();
        entity.Completed = true;
        await _context.SaveChangesAsync();
    }
}
