using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Specifications
{
    public class MissionSearchSpecification : BaseSpecification<Mission>
    {
        public MissionSearchSpecification(string searchString)
                : base(m => m.Address.Contains(searchString))
        {
            ApplyOrderByDescending(x => x.CreatedAt);
        }

    }
}
