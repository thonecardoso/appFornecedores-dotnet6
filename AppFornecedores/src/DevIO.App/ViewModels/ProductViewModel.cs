using DevIO.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(1000, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }
        public IFormFile UploadImage { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Enabled?")]
        public bool Enabled { get; set; }

        public Provider ProviderViewModel { get; set; }
    }
}
