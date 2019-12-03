using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Specifications
{
    public class MissionSearchPaginatedSpecification : BaseSpecification<Mission>
    {
        public MissionSearchPaginatedSpecification(int skip, int take, string searchString)
            : base(m => m.Address.Contains(searchString))
        {
            ApplyOrderByDescending(x => x.CreatedAt);
            ApplyPaging(skip, take);
        }

    }
}
