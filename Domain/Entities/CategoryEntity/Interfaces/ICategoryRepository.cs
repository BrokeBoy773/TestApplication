namespace Domain.Entities.CategoryEntity.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllСategoriesAsync(CancellationToken cancellationToken);

        public Task<Category?> CreateCategoryAsync(Category category, CancellationToken cancellationToken);

        public Task<Guid> UpdateCategoryAsync(Guid id, Category category, CancellationToken cancellationToken);

        public Task<Guid> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}
