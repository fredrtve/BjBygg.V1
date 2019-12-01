using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionDetailedViewModel
    {
        public MissionDetailedViewModel(){}
        public MissionDetailedViewModel(Mission mission)
        {
            Id = mission.Id;
            Name = mission.Name;
            PhoneNumber = mission.PhoneNumber;
            Description = mission.Description;
            Address = mission.Address;
            MissionImages = mission.MissionImages.Select(a => a.FileURL).ToList();
            MissionImageCount = mission.MissionImages.Count();
            MissionType = mission.MissionType;
            MissionNotesPinned = mission.MissionNotes
                .Where(a => a.Pinned == true)
                .Select(a => new MissionNoteViewModel(a))
                .OrderByDescending(a => a.CreatedAt).ToList();
            MissionNotes = mission.MissionNotes
                .Where(a => a.Pinned == false)
                .Select(a => new MissionNoteViewModel(a))
                .OrderByDescending(a => a.CreatedAt).ToList();
            MissionNoteCount = mission.MissionNotes.Count();
            Employer = mission.Employer != null ? new EmployerViewModel(mission.Employer) : null;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Uri> MissionImages { get; set; }

        public int MissionImageCount { get; set; }
        public List<MissionNoteViewModel> MissionNotesPinned { get; set; }
        public List<MissionNoteViewModel> MissionNotes { get; set; }
        public int MissionNoteCount { get; set; }
        public MissionType MissionType { get; set; }
        public EmployerViewModel Employer { get; set; }
    }
}
