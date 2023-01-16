using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevIO.Application.ViewModels;

namespace DevIO.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DevIO.Application.ViewModels.ProviderViewModel> ProviderViewModel { get; set; }
        public DbSet<DevIO.Application.ViewModels.ProductViewModel> ProductViewModel { get; set; }
    }
}