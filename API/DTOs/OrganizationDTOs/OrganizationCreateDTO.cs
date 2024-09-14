namespace API.DTOs.OrganizationDTOs
{
    public record OrganizationCreateDTO(string Name, string Address, string? Description, Guid CategoryId, List<Guid> TagIds);
}
