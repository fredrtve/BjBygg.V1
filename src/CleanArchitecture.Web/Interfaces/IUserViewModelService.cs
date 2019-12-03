using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IUserViewModelService
    {
        Task<bool> CreateUserFromViewModel(UserViewModel user, string password);

        Task<bool> UpdateUserFromViewModel(UserViewModel userView);

        IEnumerable<SelectListItem> GetRoles(string? selectedRole = null);

        Task<UserViewModel> GetUserFromId(string userName);

        Task<bool> DeleteUserByUserName(string userName);
    }
}
