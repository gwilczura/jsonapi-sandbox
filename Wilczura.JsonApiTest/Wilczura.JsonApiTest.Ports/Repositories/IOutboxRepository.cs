﻿namespace Wilczura.JsonApiTest.Ports.Repositories;

public interface IOutboxRepository
{
    Task<long> AddMessageAsync(string eventName, int entityId);
    Task CompleteMessageAsync(long messageId);
}
