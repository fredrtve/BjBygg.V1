using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserViewModelService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserViewModel> GetUserFromId(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userView = new UserViewModel(user);
            userView.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            return userView;
        }

        public async Task<bool> DeleteUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateUserFromViewModel(UserViewModel userView, string password)
        {
            if (userView.Role == "Leder") return false; //Not allowing new leaders
            var user = new ApplicationUser()
            {
                UserName = userView.UserName,
                Email = userView.Email,
                FirstName = userView.FirstName,
                LastName = userView.LastName,
                PhoneNumber = userView.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userView.Role);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUserFromViewModel(UserViewModel userView)
        {
            if (userView.Role == "Leder") return false; //Not allowing new leaders

            var user = await _userManager.FindByNameAsync(userView.UserName);

            user.Email = userView.Email;
            user.FirstName = userView.FirstName;
            user.LastName = userView.LastName;
            user.PhoneNumber = userView.PhoneNumber;        

            var result = await _userManager.UpdateAsync(user);

            var currentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (result.Succeeded && currentRole != userView.Role)
            {
                await _userManager.RemoveFromRoleAsync(user, currentRole);
                await _userManager.AddToRoleAsync(user, userView.Role);
                return true;
            }

            return false;
        }

        public IEnumerable<SelectListItem> GetRoles(string? selectedRole = null)
        {
            var items = new List<SelectListItem>();

            foreach (var role in  _roleManager.Roles.Where(x => x.Name != "Leder"))
            {
                if (role.Name == selectedRole)
                    items.Add(new SelectListItem() { Value = role.Name, Text = role.Name, Selected = true });
                else if (role.Name == "Ansatt" && selectedRole == null)
                    items.Add(new SelectListItem() { Value = role.Name, Text = role.Name, Selected = true });
                else
                    items.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            return items;
        }
    }
}
