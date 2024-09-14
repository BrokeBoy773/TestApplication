using Application.Services;
using Domain.Entities.OrganizationEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class OrganizationServiceExtensions
    {
        public static void AddOrganizationService(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOrganizationService, OrganizationService>();
        }
    }
}
