using API.DTOs.CategoryDTOs;
using Domain.Entities.CategoryEntity;
using Domain.Entities.CategoryEntity.Interfaces;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(ILogger<CategoryController> logger, ICategoryService service) : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger = logger;
        private readonly ICategoryService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllСategoriesAsync(CancellationToken cancellationToken)
        {
            List<Category> categories = await _service.GetAllСategoriesAsync(cancellationToken);

            return Ok(categories.Adapt<List<CategoryGetDTO>>());
        }

        [HttpPost]
        public async Task<ActionResult<Category?>> CreateCategoryAsync([FromBody] CategoryCreateDTO categoryCreateDTO, CancellationToken cancellationToken)
        {
            (Category newCategory, ValidationResult result) = Category.CreateCategory(Guid.NewGuid(), categoryCreateDTO.Name, categoryCreateDTO.Description);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.CreateCategoryAsync(newCategory, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCategoryAsync([FromRoute] Guid id, [FromBody] CategoryCreateDTO categoryCreateDTO, CancellationToken cancellationToken)
        {
            (Category newCategory, ValidationResult result) = Category.CreateCategory(Guid.NewGuid(), categoryCreateDTO.Name, categoryCreateDTO.Description);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.UpdateCategoryAsync(id, newCategory, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCategoryAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _service.DeleteCategoryAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
