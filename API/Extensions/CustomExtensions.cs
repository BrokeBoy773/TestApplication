using API.Extensions.Databases;
using API.Extensions.Mappings;
using API.Extensions.Services;
using API.Extensions.Validations;

namespace API.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            DbContextExtensions.AddDbContext(services, configuration);

            MappingExtensions.AddMapping(services);

            ValidatorExtensions.AddValidator(services);

            CategoryServiceExtensions.AddCategoryService(services);
            OrganizationServiceExtensions.AddOrganizationService(services);
            TagServiceExtensions.AddTagService(services);
        }
    }
}
