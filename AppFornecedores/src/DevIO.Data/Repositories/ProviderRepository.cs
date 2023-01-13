using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

public class ProviderRepository : Repository<Provider>, IProviderRepository
{
    public ProviderRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<Provider> GetProviderAddress(Guid id) =>
        await _db.Providers.AsNoTracking()
                           .Include(c => c.Address)
                           .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Provider> GetProviderProductsAddress(Guid id) =>
        await _db.Providers.AsNoTracking()
                           .Include(c => c.Products)
                           .Include(c => c.Address)
                           .FirstOrDefaultAsync(c => c.Id == id);
}