using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specifications;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Services
{
    public class MissionListViewModelService : IMissionListViewModelService
    {
        private readonly IAsyncRepository<Mission> _repository;

        public MissionListViewModelService(IAsyncRepository<Mission> repository)
        {
            _repository = repository;
        }

        public async Task<MissionListViewModel> GetMissionList(int pageIndex, int itemsPage, string? searchString)
        {
            IReadOnlyList<Mission> itemsOnPage;
            int totalItems;

            if (String.IsNullOrEmpty(searchString))
            {
                itemsOnPage = await _repository.ListAsync(new MissionPaginatedSpecification(itemsPage * pageIndex, itemsPage));
                totalItems = await _repository.CountAsync();
            }
            else
            {
                var formatedSearchString = new CultureInfo("nb-NO", false).TextInfo.ToTitleCase(searchString);
                itemsOnPage = await _repository.ListAsync(new MissionSearchPaginatedSpecification(itemsPage * pageIndex, itemsPage, formatedSearchString));
                totalItems = await _repository.CountAsync(new MissionSearchSpecification(formatedSearchString));
            }

            var vm = new MissionListViewModel()
            {
                Missions = itemsOnPage.Select(b => new MissionListItemViewModel(b)).ToList(),
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            //Disable next or previous for out of range pages
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "disabled" : "";

            return vm;
        }

    }
}
