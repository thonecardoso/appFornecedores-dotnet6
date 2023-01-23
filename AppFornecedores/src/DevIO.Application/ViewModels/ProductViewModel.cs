using DevIO.Application.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Provider")]
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(1000, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [DisplayName("Product Image")]
        public IFormFile? UploadImage { get; set; }
        public string? Image { get; set; }

        [Currency]
        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Enabled?")]
        public bool Enabled { get; set; }

        public ProviderViewModel? Provider { get; set; }
        public IEnumerable<ProviderViewModel>? Providers { get; set; }
    }
}
