using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Application.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Number { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string Complement { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(8, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 8)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string District { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must have beetween {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }

        [HiddenInput]
        public Guid ProviderId { get; set; }
    }
}
