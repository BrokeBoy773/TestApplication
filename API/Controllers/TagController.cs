using API.DTOs.TagDTOs;
using Domain.Entities.TagEntity;
using Domain.Entities.TagEntity.Interfaces;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController(ILogger<TagController> logger, ITagService service) : ControllerBase
    {
        private readonly ILogger<TagController> _logger = logger;
        private readonly ITagService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Tag>>> GetAllTagsAsync(CancellationToken cancellationToken)
        {
            List<Tag> tags = await _service.GetAllTagsAsync(cancellationToken);

            return Ok(tags.Adapt<List<TagGetDTO>>());
        }

        [HttpPost]
        public async Task<ActionResult<Tag?>> CreateTagAsync([FromBody] TagCreateDTO tagCreateDTO, CancellationToken cancellationToken)
        {
            (Tag newTag, ValidationResult result) = Tag.CreateTag(Guid.NewGuid(), tagCreateDTO.Name, tagCreateDTO.Description);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.CreateTagAsync(newTag, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateTagAsync([FromRoute] Guid id, [FromBody] TagCreateDTO tagCreateDTO, CancellationToken cancellationToken)
        {
            (Tag newTag, ValidationResult result) = Tag.CreateTag(Guid.NewGuid(), tagCreateDTO.Name, tagCreateDTO.Description);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.UpdateTagAsync(id, newTag, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteTagAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _service.DeleteTagAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
