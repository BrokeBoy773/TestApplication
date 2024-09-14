using Domain.Entities.OrganizationEntity;
using FluentValidation;

namespace API.Extensions.Validations
{
    public static class ValidatorExtensions
    {
        public static void AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<OrganizationValidator>();
        }
    }
}
