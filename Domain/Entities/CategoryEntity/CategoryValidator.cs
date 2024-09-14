using Domain.Validations;
using FluentValidation;

namespace Domain.Entities.CategoryEntity
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotNullNotEmptyMaximum256Characters();
            RuleFor(c => c.Description).Maximum256Characters();
        }
    }
}
