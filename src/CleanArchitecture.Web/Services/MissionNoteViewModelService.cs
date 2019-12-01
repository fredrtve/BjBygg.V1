using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Services
{
    public class MissionNoteViewModelService : IMissionNoteViewModelService
    {
        private readonly IAsyncRepository<MissionNote> _asyncRepository;

        public MissionNoteViewModelService(IAsyncRepository<MissionNote> asyncRepository)
        {
            this._asyncRepository = asyncRepository;
        }

        public async Task<MissionNote> CreateMissionNotesFromViewModel(MissionNoteViewModel noteModel)
        {
            return await _asyncRepository.AddAsync(new MissionNote()
            {
                Title = noteModel.Title,
                Content = noteModel.Content,
                MissionId =  noteModel.MissionId,
                Pinned = noteModel.Pinned
            });
        }

        public async Task<bool> DeleteMissionNoteById(int id)
        {
            var note = await _asyncRepository.GetByIdAsync(id);
            if (note != null)
            {
                await _asyncRepository.DeleteAsync(note);
                return true;
            }
            else return false;
        }
    }
}
