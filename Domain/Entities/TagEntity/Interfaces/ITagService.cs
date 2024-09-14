namespace Domain.Entities.TagEntity.Interfaces
{
    public interface ITagService
    {
        public Task<List<Tag>> GetAllTagsAsync(CancellationToken cancellationToken);

        public Task<Tag?> CreateTagAsync(Tag tag, CancellationToken cancellationToken);

        public Task<Guid> UpdateTagAsync(Guid id, Tag tag, CancellationToken cancellationToken);

        public Task<Guid> DeleteTagAsync(Guid id, CancellationToken cancellationToken);
    }
}
