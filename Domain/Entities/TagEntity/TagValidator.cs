using Domain.Validations;
using FluentValidation;

namespace Domain.Entities.TagEntity
{
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(t => t.Name).NotNullNotEmptyMaximum256Characters();
            RuleFor(t => t.Description).Maximum256Characters();
        }
    }
}
