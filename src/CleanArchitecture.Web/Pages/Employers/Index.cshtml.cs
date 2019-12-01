using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Pages.Employers
{
    [Authorize(Roles = "Leder, Mellomleder")]
    public class IndexModel : PageModel
    {
        private readonly IEmployerViewModelService _service;

        public IndexModel(IEmployerViewModelService service)
        {
            _service = service;
        }

        public IEnumerable<EmployerViewModel> Employers { get; set; }

        public async Task OnGet()
        {
            Employers = await _service.GetEmployers();
        }


    }
}
