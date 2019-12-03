using CleanArchitecture.Web.ViewModels;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IMissionDetailedViewModelService
    {
        Task<MissionDetailedViewModel> GetMissionDetailed(int id);
    }
}
