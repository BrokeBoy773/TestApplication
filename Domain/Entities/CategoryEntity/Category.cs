using Domain.Entities.OrganizationEntity;
using FluentValidation.Results;

namespace Domain.Entities.CategoryEntity
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public List<Organization> Organizations { get; private set; } = [];


        private Category() { }
        private Category(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static (Category Category, ValidationResult ValidationResult) CreateCategory(Guid id, string name, string? description)
        {
            Category category = new(id, name, description);

            CategoryValidator validator = new();
            ValidationResult result = validator.Validate(category);

            return (category, result);
        }
    }
}
