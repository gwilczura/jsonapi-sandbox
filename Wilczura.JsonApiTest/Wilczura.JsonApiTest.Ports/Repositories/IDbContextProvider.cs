namespace Wilczura.JsonApiTest.Ports.Repositories;

public interface IDbContextProvider
{
    object GetContext();
}
