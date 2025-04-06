namespace Wilczura.JsonApiTest.Ports.Publishers;

public interface IEntityChangedPublisher
{
    Task PublishEntityChangedAsync(string eventName, int entityId);
}
