using CleanArchitecture.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionTypeViewModel
    {
        public MissionTypeViewModel() { }
        public MissionTypeViewModel(MissionType type)
        {
            Id = type.Id;
            Name = type.Name;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [StringLength(45, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        [Display(Name = "Navn")]
        public string Name { get; set; }
    }
}
