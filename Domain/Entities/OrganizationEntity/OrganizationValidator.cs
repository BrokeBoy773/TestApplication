using Domain.Validations;
using FluentValidation;

namespace Domain.Entities.OrganizationEntity
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(o => o.Name).NotNullNotEmptyMaximum256Characters();
            RuleFor(o => o.Address).NotNullNotEmptyMaximum256Characters();
            RuleFor(o => o.Description).Maximum256Characters();
        }
    }
}
