﻿using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address> GetAddressByProvider(Guid providerId);
}