using Domain.Entities.TagEntity;
using Domain.Entities.TagEntity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Tag>> GetAllTagsAsync(CancellationToken cancellationToken)
        {
            List<Tag> tags = await _context.Tags
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return tags;
        }

        public async Task<Tag?> CreateTagAsync(Tag tag, CancellationToken cancellationToken)
        {
            await _context.Tags.AddAsync(tag, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return tag;
        }

        public async Task<Guid> UpdateTagAsync(Guid id, Tag tag, CancellationToken cancellationToken)
        {
            await _context.Tags
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(t => t.Name, t => tag.Name)
                                          .SetProperty(t => t.Description, t => tag.Description),
                                          cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteTagAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Tags
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
