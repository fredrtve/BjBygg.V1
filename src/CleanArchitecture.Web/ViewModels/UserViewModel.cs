using CleanArchitecture.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() {}
        public UserViewModel(ApplicationUser user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
        }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Brukernavn")]
        [StringLength(45, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Fornavn")]
        [StringLength(45, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Etternavn")]
        [StringLength(45, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string LastName { get; set; }

        [Display(Name = "Mobil")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12, ErrorMessage = "{0} må være mellom {2} og {1} tegn.", MinimumLength = 4)]        
        public string PhoneNumber { get; set; }

        [Display(Name = "Epost")]
        [EmailAddress(ErrorMessage = "Epost adressen er ikke gyldig.")]
        public string Email { get; set; }

        [Display(Name = "Rolle")]
        [Required]
        public string Role { get; set; }
    }
}
