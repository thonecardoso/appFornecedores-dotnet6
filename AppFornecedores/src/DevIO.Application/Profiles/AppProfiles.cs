using AutoMapper;
using DevIO.Application.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Application.Profiles;

public class AppProfiles : Profile
{
    public AppProfiles()
    {
        CreateMap<Provider, ProviderViewModel>().ReverseMap();
        CreateMap<Address, AddressViewModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
    }
}
