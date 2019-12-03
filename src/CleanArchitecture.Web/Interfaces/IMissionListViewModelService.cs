using CleanArchitecture.Web.ViewModels;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IMissionListViewModelService
    {
        Task<MissionListViewModel> GetMissionList(int pageIndex, int itemsPage, string searchString = null);
    }
}
