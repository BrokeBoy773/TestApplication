using Domain.Entities.OrganizationEntity;
using Domain.Entities.OrganizationEntity.Interfaces;

namespace Application.Services
{
    public class OrganizationService(IOrganizationRepository repository) : IOrganizationService
    {
        private readonly IOrganizationRepository _repository = repository;

        public async Task<List<Organization>> GetAllOrganizationsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllOrganizationsAsync(cancellationToken);
        }

        public async Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetOrganizationByIdAsync(id, cancellationToken);
        }

        public async Task<Organization?> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken)
        {
            return await _repository.CreateOrganizationAsync(organization, cancellationToken);
        }

        public async Task<Guid> UpdateOrganizationAsync(Guid id, Organization organization, CancellationToken cancellationToken)
        {
            return await _repository.UpdateOrganizationAsync(id, organization, cancellationToken);
        }

        public async Task<Guid> DeleteOrganizationAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteOrganizationAsync(id, cancellationToken);
        }
    }
}
