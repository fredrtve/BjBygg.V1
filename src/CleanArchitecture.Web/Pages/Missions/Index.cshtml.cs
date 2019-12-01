using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Core.Specifications;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Pages.Missions
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMissionListViewModelService _missionListService;

        public IndexModel(IMissionListViewModelService missionListService)
        {
            _missionListService = missionListService;
        }

        public MissionListViewModel MissionList { get; set; }

        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public async Task OnGet(string searchString, int? pageId)
        {
           MissionList = await _missionListService.GetMissionList(pageId ?? 0, Constants.ITEMS_PER_PAGE, searchString);
           MissionList.PaginationInfo.CurrentFilter = searchString;
        }
    }
}
