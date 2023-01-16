using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<Product> GetProductProvider(Guid id)
    {
        return await _db.Products.AsNoTracking().Include(f => f.Provider).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
    {
        return await Get(p => p.ProviderId == providerId);
        
    }

    public async Task<IEnumerable<Product>> GetProductsProviders()
    {
        return await _db.Products.AsNoTracking().Include(f => f.Provider)
            .OrderBy(p => p.Name).ToListAsync();
    }
}