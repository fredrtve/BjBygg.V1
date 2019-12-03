using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Specifications
{
    public class EmployerByNameSpecification : BaseSpecification<Employer>
    {
        public EmployerByNameSpecification(string employerName)
                : base(m => m.Name == employerName)
        {

        }

    }
}
