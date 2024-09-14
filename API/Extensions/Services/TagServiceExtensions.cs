using Application.Services;
using Domain.Entities.TagEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class TagServiceExtensions
    {
        public static void AddTagService(this IServiceCollection services)
        {
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();
        }
    }
}
