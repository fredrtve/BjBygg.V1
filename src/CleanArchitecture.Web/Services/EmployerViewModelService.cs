using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Services
{
    public class EmployerViewModelService : IEmployerViewModelService
    {
        private readonly IAsyncRepository<Employer> _employerRepository;

        public EmployerViewModelService(IAsyncRepository<Employer> employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<IEnumerable<EmployerViewModel>> GetEmployers()
        {
            var employers = await _employerRepository.ListAllAsync();
            return employers.Select(a => new EmployerViewModel(a));
        }

        public async Task<EmployerViewModel> GetEmployer(int id)
        {
            var employer = await _employerRepository.GetByIdAsync(id);

            return new EmployerViewModel(employer);
        }

        public async Task<Employer> CreateEmployerFromViewModel(EmployerViewModel employerModel)
        {
            return await _employerRepository.AddAsync(new Employer()
            {
                Address = employerModel.Address,
                PhoneNumber = employerModel.PhoneNumber,
                Name = employerModel.Name
            });
        }

        public async Task UpdateEmployerFromViewModel(EmployerViewModel employerModel)
        {
            await _employerRepository.UpdateAsync(new Employer()
            {
                Id = employerModel.Id,
                Address = employerModel.Address,
                PhoneNumber = employerModel.PhoneNumber,
                Name = employerModel.Name
            });
        }

        public async Task<bool> DeleteEmployerById(int id)
        {
            var employer = await _employerRepository.GetByIdAsync(id);
            if (employer != null)
            {
                await _employerRepository.DeleteAsync(employer);
                return true;
            }
            else return false;
        }
    }
}
