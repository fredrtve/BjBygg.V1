using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IEmployerViewModelService
    {
        Task<IEnumerable<EmployerViewModel>> GetEmployers();
        Task<EmployerViewModel> GetEmployer(int id);
        Task<Employer> CreateEmployerFromViewModel(EmployerViewModel missionModel);
        Task UpdateEmployerFromViewModel(EmployerViewModel missionModel);
        Task<bool> DeleteEmployerById(int id);
    }
}
