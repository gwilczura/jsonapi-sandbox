namespace Wilczura.Common.Ports.Repositories;

public interface IDbContextProvider
{
    object GetContext();
}
