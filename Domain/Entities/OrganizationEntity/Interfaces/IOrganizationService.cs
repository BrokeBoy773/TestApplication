namespace Domain.Entities.OrganizationEntity.Interfaces
{
    public interface IOrganizationService
    {
        public Task<List<Organization>> GetAllOrganizationsAsync(CancellationToken cancellationToken);

        public Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<Organization?> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken);

        public Task<Guid> UpdateOrganizationAsync(Guid id, Organization organization, CancellationToken cancellationToken);

        public Task<Guid> DeleteOrganizationAsync(Guid id, CancellationToken cancellationToken);
    }
}
