using API.Mappings.Configurations;

namespace API.Mappings
{
    public static class DTOMappingConfiguration
    {
        public static void RegisterDtoMapping()
        {
            CategoryDTOMappingConfiguration.RegisterMapping();
            OrganizationDTOMappingConfiguration.RegisterMapping();
            TagDTOMappingConfiguration.RegisterMapping();
        }
    }
}
