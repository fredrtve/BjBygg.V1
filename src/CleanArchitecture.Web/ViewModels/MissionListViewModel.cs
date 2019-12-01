using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionListViewModel
    {
        public MissionListViewModel() { }

        public PaginationInfoViewModel PaginationInfo { get; set; }
        public List<MissionListItemViewModel> Missions { get; set; }

    }

}
