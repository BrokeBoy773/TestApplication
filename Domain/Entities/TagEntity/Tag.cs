using Domain.Entities.OrganizationEntity;
using FluentValidation.Results;

namespace Domain.Entities.TagEntity
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public List<Organization> Organizations { get; private set; } = [];


        private Tag() { }
        private Tag(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static (Tag Tag, ValidationResult ValidationResult) CreateTag(Guid id, string name, string? description)
        {
            Tag tag = new(id, name, description);

            TagValidator validator = new();
            ValidationResult result = validator.Validate(tag);

            return (tag, result);
        }
    }
}
