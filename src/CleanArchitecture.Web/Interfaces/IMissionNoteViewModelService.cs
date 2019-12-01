using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IMissionNoteViewModelService
    {
        Task<MissionNote> CreateMissionNotesFromViewModel(MissionNoteViewModel noteModel);
        Task<bool> DeleteMissionNoteById(int id);
    }
}
