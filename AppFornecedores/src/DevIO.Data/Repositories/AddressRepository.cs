using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<Address> GetAddressByProvider(Guid providerId) =>
        await _db.Addresses.AsNoTracking()
                           .FirstOrDefaultAsync(p => p.ProviderId == providerId);
    
}