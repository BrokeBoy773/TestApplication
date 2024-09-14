using FluentValidation;

namespace Domain.Validations
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string?> NotNullNotEmptyMaximum256Characters<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().WithMessage("Null")
                .NotEmpty().WithMessage("Empty")
                .MaximumLength(256).WithMessage("Exceed 256 characters");
        }

        public static IRuleBuilderOptions<T, string?> Maximum256Characters<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(256).WithMessage("Exceed 256 characters");
        }
    }
}
