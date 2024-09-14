using API.Mappings;
using Mapster;
using MapsterMapper;

namespace API.Extensions.Mappings
{
    public static class MappingExtensions
    {
        public static void AddMapping(this IServiceCollection services)
        {
            DTOMappingConfiguration.RegisterDtoMapping();

            services.AddSingleton<IMapper>(new Mapper(TypeAdapterConfig.GlobalSettings));
        }
    }
}
