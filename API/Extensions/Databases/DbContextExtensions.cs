using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions.Databases
{
    public static class DbContextExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
            });
        }
    }
}
