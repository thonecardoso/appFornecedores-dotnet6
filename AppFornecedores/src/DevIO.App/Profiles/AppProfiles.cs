using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Models;

namespace DevIO.App.Profiles
{
    public class AppProfiles : Profile
    {
        public AppProfiles()
        {
            CreateMap<Provider, ProviderViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
