using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IMissionViewModelService
    {
        Task<MissionViewModel> GetMissionById(int id);

        Task<bool> DeleteMissionById(int id);
        Task<Mission> CreateMissionFromViewModel(MissionViewModel missionModel);
        Task UpdateMissionFromViewModel(MissionViewModel missionModel);

        Task<IEnumerable<SelectListItem>> GetTypes(int? selectedTypeId = null);

        Task<IEnumerable<SelectListItem>> GetEmployers(int? selectedEmployerId = null);
    }
}
