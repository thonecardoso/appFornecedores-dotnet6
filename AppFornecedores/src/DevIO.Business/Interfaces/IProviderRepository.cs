using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IProviderRepository : IRepository<Provider>
{
    Task<Provider> GetProviderAddress(Guid id);
    Task<Provider> GetProviderProductsAddress(Guid id);
}
