using CleanArchitecture.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionViewModel
    {
        public MissionViewModel() { }
        public MissionViewModel(Mission mission)
        {
            Id = mission.Id;
            Name = mission.Name;
            PhoneNumber = mission.PhoneNumber;
            Description = mission.Description;
            Address = mission.Address;
            MissionTypeId = mission.MissionTypeId;
            EmployerId = mission.EmployerId;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Adresse")]
        [StringLength(100, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string Address { get; set; }


        [Display(Name = "Navn")]
        [StringLength(50, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string? Name { get; set; }

        [Display(Name = "Mobilnr")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12, ErrorMessage = "{0} må være mellom {2} og {1} tegn.", MinimumLength = 4)]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Beskrivelse")]
        [StringLength(400, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string? Description { get; set; }

        [Display(Name = "Oppdragstype")]
        public int? MissionTypeId { get; set; }

        [Display(Name = "Oppdragsgiver")]
        public int? EmployerId { get; set; }
    }
}
