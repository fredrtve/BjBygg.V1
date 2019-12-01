using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using CleanArchitecture.Core.Specifications;
using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Services
{
    public class MissionDetailedViewModelService : IMissionDetailedViewModelService
    {
        private readonly IAsyncRepository<Mission> _missionRepository;

        public MissionDetailedViewModelService(IAsyncRepository<Mission> missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<MissionDetailedViewModel> GetMissionDetailed(int id)
        {
            var mission = await _missionRepository.ListAsync(new MissionDetailedSpecification(id));
            return new MissionDetailedViewModel(mission.FirstOrDefault());
        }


        
    }

}
