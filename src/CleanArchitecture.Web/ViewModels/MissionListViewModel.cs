using System.Collections.Generic;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionListViewModel
    {
        public MissionListViewModel() { }

        public PaginationInfoViewModel PaginationInfo { get; set; }
        public List<MissionListItemViewModel> Missions { get; set; }

    }

}
