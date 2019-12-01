using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class EmployerViewModel
    {
        public EmployerViewModel(){}
        public EmployerViewModel(Employer employer)
        {                      
            Id = employer.Id;
            Name = employer.Name;
            PhoneNumber = employer.PhoneNumber;
            Address = employer.Address;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Navn")]
        [StringLength(50, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string Name { get; set; }

        [Display(Name = "Mobilnr")]
        [StringLength(12, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Adresse")]
        [StringLength(100, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string? Address { get; set; }
    }
}
