﻿using API.DTOs.TagDTOs;
using Domain.Entities.TagEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public static class TagDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Tag, TagGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);
        }
    }
}
