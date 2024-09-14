using Domain.Entities.TagEntity;
using Domain.Entities.TagEntity.Interfaces;

namespace Application.Services
{
    public class TagService(ITagRepository repository) : ITagService
    {
        private readonly ITagRepository _repository = repository;

        public async Task<List<Tag>> GetAllTagsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllTagsAsync(cancellationToken);
        }

        public async Task<Tag?> CreateTagAsync(Tag tag, CancellationToken cancellationToken)
        {
            return await _repository.CreateTagAsync(tag, cancellationToken);
        }

        public async Task<Guid> UpdateTagAsync(Guid id, Tag tag, CancellationToken cancellationToken)
        {
            return await _repository.UpdateTagAsync(id, tag, cancellationToken);
        }

        public async Task<Guid> DeleteTagAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteTagAsync(id, cancellationToken);
        }
    }
}
