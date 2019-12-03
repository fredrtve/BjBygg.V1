using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Specifications
{
    public class MissionTypeByNameSpecification : BaseSpecification<MissionType>
    {
        public MissionTypeByNameSpecification(string typeName)
                : base(m => m.Name == typeName)
        {

        }

    }
}
