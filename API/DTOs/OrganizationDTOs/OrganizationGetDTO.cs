using API.DTOs.CategoryDTOs;
using API.DTOs.TagDTOs;

namespace API.DTOs.OrganizationDTOs
{
    public record OrganizationGetDTO(Guid Id, string Name, string Address, string? Description,
                                     CategoryGetDTO Category, List<TagGetDTO> Tags);
}
