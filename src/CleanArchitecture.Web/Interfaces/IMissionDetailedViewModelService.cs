using CleanArchitecture.Web.ViewModels;
using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IMissionDetailedViewModelService
    {
        Task<MissionDetailedViewModel> GetMissionDetailed(int id);
    }
}
