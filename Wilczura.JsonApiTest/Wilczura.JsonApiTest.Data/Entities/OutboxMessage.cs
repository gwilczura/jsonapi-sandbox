using JsonApiDotNetCore.Resources.Annotations;

namespace Wilczura.JsonApiTest.Data.Entities;

[NoResource]
public class OutboxMessage
{
    public long OutboxMessageId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public bool Completed {  get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
}
