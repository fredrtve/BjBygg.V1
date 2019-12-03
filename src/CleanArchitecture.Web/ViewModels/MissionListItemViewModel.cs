using CleanArchitecture.Core.Entities;
using System;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionListItemViewModel
    {
        public MissionListItemViewModel(Mission mission)
        {
            Id = mission.Id;
            Address = mission.Address;
            CreatedAt = mission.CreatedAt;
        }
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
