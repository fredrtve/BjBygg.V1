using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Pages.Missions
{
    [Authorize]
    public class MissionModel : PageModel
    {
        private readonly IMissionDetailedViewModelService _missionService;
        private readonly IMissionNoteViewModelService _noteService;
        private readonly IMissionImageUploader _imageUploader;

        public MissionModel(IMissionDetailedViewModelService missionService, IMissionNoteViewModelService noteService, IMissionImageUploader imageUploader)
        {
            _missionService = missionService;
            _noteService = noteService;
            _imageUploader = imageUploader;
        }

        public MissionDetailedViewModel Mission { get; set; }
        public bool? Uploaded { get; set; }

        public int? FileCount { get; set; }

        public async Task OnGet(int id, bool? uploaded, int? fileCount)
        {
            Mission = await _missionService.GetMissionDetailed(id);
            Uploaded = uploaded;
            FileCount = fileCount;          
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var uploaded = true;
            try
            {
                var request = await HttpContext.Request.ReadFormAsync();
                var files = request.Files;
                var fileCount = files.Count;

                if (files == null || fileCount == 0)
                {
                    uploaded = false;
                    return RedirectToPage("./Mission", new { id, uploaded });
                }

                await _imageUploader.UploadCollection(files, id);
                
                return RedirectToPage("./Mission", new { id, uploaded, fileCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> OnGetDeleteNote(int noteId, int missionId)
        {
            var success = await _noteService.DeleteMissionNoteById(noteId);
            if (success) return RedirectToPage("./Mission", new { id = missionId });
            else return BadRequest("Fant ikke notat");
        }
    }
}
