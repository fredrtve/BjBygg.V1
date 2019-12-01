using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Pages.Missions.Notes
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IMissionNoteViewModelService _service;

        public CreateModel(IMissionNoteViewModelService service)
        {
            _service = service;
        }

        [BindProperty]
        public MissionNoteViewModel Note { get; set; } = new MissionNoteViewModel();

        public void OnGet(int id)
        {
            Note.MissionId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
  
            await _service.CreateMissionNotesFromViewModel(Note);

            return RedirectToPage("/Missions/Mission", new { Id = Note.MissionId });
        }
    }
}
