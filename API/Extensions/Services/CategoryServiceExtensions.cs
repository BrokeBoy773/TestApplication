using Application.Services;
using Domain.Entities.CategoryEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class CategoryServiceExtensions
    {
        public static void AddCategoryService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
