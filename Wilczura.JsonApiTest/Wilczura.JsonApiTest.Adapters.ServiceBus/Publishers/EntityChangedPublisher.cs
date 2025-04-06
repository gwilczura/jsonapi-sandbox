using Wilczura.JsonApiTest.Ports.Publishers;

namespace Wilczura.JsonApiTest.Adapters.ServiceBus.Publishers;

public class EntityChangedPublisher : IEntityChangedPublisher
{
    public async Task PublishEntityChangedAsync(string eventName, int entityId)
    {
        // TODO: enable subscribing handlers based on event name
        Console.WriteLine($"PublishEntityChangedAsync {eventName} {entityId}");
        await Task.CompletedTask;
    }
}
