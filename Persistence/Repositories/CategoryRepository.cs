using Domain.Entities.CategoryEntity;
using Domain.Entities.CategoryEntity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Category>> GetAllСategoriesAsync(CancellationToken cancellationToken)
        {
            List<Category> categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return categories;
        }

        public async Task<Category?> CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task<Guid> UpdateCategoryAsync(Guid id, Category category, CancellationToken cancellationToken)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(c => c.Name, c => category.Name)
                                          .SetProperty(c => c.Description, c => category.Description),
                                          cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
