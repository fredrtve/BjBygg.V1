using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Services
{
    public class MissionViewModelService : IMissionViewModelService
    {
        private readonly IAsyncRepository<Mission> _missionRepository;
        private readonly IAsyncRepository<MissionType> _typeRepository;
        private readonly IAsyncRepository<Employer> _employerRepository;

        public MissionViewModelService(
            IAsyncRepository<Mission> missionRepository,
            IAsyncRepository<MissionType> typeRepository,
            IAsyncRepository<Employer> employerRepository)
        {
            _missionRepository = missionRepository;
            _typeRepository = typeRepository;
            _employerRepository = employerRepository;
        }

        public async Task<MissionViewModel> GetMissionById(int id)
        {
            var mission = await _missionRepository.GetByIdAsync(id);

            return new MissionViewModel(mission);
        }

        public async Task<bool> DeleteMissionById(int id)
        {
            var mission = await _missionRepository.GetByIdAsync(id);
            if (mission != null)
            {
                await _missionRepository.DeleteAsync(mission);
                return true;
            }
            else return false;
        }

        public async Task<Mission> CreateMissionFromViewModel(MissionViewModel missionModel)
        {
            return await _missionRepository.AddAsync(new Mission()
            {
                Address = missionModel.Address,
                PhoneNumber = missionModel.PhoneNumber,
                Description = missionModel.Description,
                MissionTypeId = missionModel.MissionTypeId,
                EmployerId = missionModel.EmployerId
            });
        }

        public async Task UpdateMissionFromViewModel(MissionViewModel missionModel)
        {
            await _missionRepository.UpdateAsync(new Mission()
            {
                Id = missionModel.Id,
                Address = missionModel.Address,
                PhoneNumber = missionModel.PhoneNumber,
                Description = missionModel.Description,
                MissionTypeId = missionModel.MissionTypeId,
                EmployerId = missionModel.EmployerId
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes(int? selectedTypeId = null)
        {
            var items = new List<SelectListItem>();

            if (selectedTypeId == null)
                items.Add(new SelectListItem() { Value = "", Text = "Ingen", Selected = true });
            else
                items.Add(new SelectListItem() { Value = "", Text = "Ingen" });

            foreach (var type in (await _typeRepository.ListAllAsync()))
            {
                if (type.Id == selectedTypeId)
                    items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Name, Selected = true });
                else
                    items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Name });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetEmployers(int? selectedEmployerId = null)
        {
            var items = new List<SelectListItem>();

            if (selectedEmployerId == null)
                items.Add(new SelectListItem() { Value = "", Text = "Ingen", Selected = true });
            else
                items.Add(new SelectListItem() { Value = "", Text = "Ingen" });

            foreach (var employer in (await _employerRepository.ListAllAsync()))
            {
                if (employer.Id == selectedEmployerId)
                    items.Add(new SelectListItem() { Value = employer.Id.ToString(), Text = employer.Name, Selected = true });
                else
                    items.Add(new SelectListItem() { Value = employer.Id.ToString(), Text = employer.Name });
            }

            return items;
        }

    }
}
