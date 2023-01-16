using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Application.ViewModels
{
    public class ProviderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(14, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 11)]
        public string Document { get; set; }

        [DisplayName("Type")]
        public int TypeProvider { get; set; }
        public AddressViewModel Address { get; set; }

        [DisplayName("Enabled?")]
        public bool Enabled { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
