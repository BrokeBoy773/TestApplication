using API.DTOs.OrganizationDTOs;
using Domain.Entities.OrganizationEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public static class OrganizationDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Organization, OrganizationGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Category, src => src.Category)
                .Map(dest => dest.Tags, src => src.Tags);
        }
    }
}
