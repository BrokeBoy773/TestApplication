using Domain.Entities.OrganizationEntity;
using Domain.Entities.OrganizationEntity.Interfaces;
using Domain.Entities.TagEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrganizationRepository(ApplicationDbContext context) : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Organization>> GetAllOrganizationsAsync(CancellationToken cancellationToken)
        {
            List<Organization> organizations = await _context.Organizations
                .AsNoTracking()
                .Include(o => o.Category)
                .Include(o => o.Tags)
                .ToListAsync(cancellationToken);

            return organizations;
        }

        public async Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Organization? organization = await _context.Organizations
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Include(o => o.Category)
                .Include(o => o.Tags)
                .FirstOrDefaultAsync(cancellationToken);

            return organization;
        }

        public async Task<Organization?> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken)
        {
            List<Tag> tags = await _context.Tags
                .Where(t => organization.TagIds.Contains(t.Id))
                .ToListAsync(cancellationToken);

            organization.AddTags(tags);

            await _context.Organizations.AddAsync(organization, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return organization;
        }

        public async Task<Guid> UpdateOrganizationAsync(Guid id, Organization organization, CancellationToken cancellationToken)
        {
            Organization? existingOrganization =  await _context.Organizations
                .Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);

            List<Tag> tags = await _context.Tags
                .Where(t => organization.TagIds.Contains(t.Id))
                .ToListAsync(cancellationToken);

            existingOrganization?.AddTags(tags);

            await _context.SaveChangesAsync(cancellationToken);

            await _context.Organizations
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(o => o.Name, o => organization.Name)
                                          .SetProperty(o => o.Address, o => organization.Address)
                                          .SetProperty(o => o.Description, o => organization.Description)
                                          .SetProperty(o => o.CategoryId, o => organization.CategoryId)
                                          .SetProperty(o => o.TagIds, o => organization.TagIds),
                                          cancellationToken);
            
            return id;
        }

        public async Task<Guid> DeleteOrganizationAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Organizations
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
