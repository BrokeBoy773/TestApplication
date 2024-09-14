using Domain.Entities.CategoryEntity;
using Domain.Entities.TagEntity;
using FluentValidation.Results;

namespace Domain.Entities.OrganizationEntity
{
    public class Organization
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;

        public List<Guid> TagIds { get; private set; } = [];
        public List<Tag> Tags { get; private set; } = [];


        private Organization() { }
        private Organization(Guid id, string name, string address, string? description, Guid categoryId, List<Guid> tagIds)
        {
            Id = id;
            Name = name;
            Address = address;
            Description = description;
            CategoryId = categoryId;
            TagIds = tagIds;
        }

        public static (Organization Organization, ValidationResult ValidationResult) CreateOrganization(Guid id, string name, string address, string? description,
                                                                                                        Guid categoryId, List<Guid> tagIds)
        {
            Organization organization = new(id, name, address, description, categoryId, tagIds);

            OrganizationValidator validator = new();
            ValidationResult result = validator.Validate(organization);

            return (organization, result);
        }

        public void AddTags(List<Tag> tags)
        {
            Tags = tags;
        }
    }
}
