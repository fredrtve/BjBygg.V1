using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Pages.Missions
{
    [Authorize(Roles = "Leder, Mellomleder")]
    public class CreateModel : PageModel
    {
        private readonly IMissionViewModelService _service;
        private readonly IConfiguration _config;

        public CreateModel(IMissionViewModelService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [BindProperty]
        public MissionViewModel Mission { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Employers { get; set; }

        public string GoogleMapsApiKey { get; set; }

        public async Task OnGet()
        {
            Types = await _service.GetTypes();
            Employers = await _service.GetEmployers();

            GoogleMapsApiKey = _config["GoogleMapsApiKey"];
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Types = await _service.GetTypes();
                Employers = await _service.GetEmployers();
                GoogleMapsApiKey = _config["GoogleMapsApiKey"];
                return Page();
            }

            await _service.CreateMissionFromViewModel(Mission);

            return RedirectToPage("./Index");
        }
    }
}
