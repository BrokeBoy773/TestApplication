using API.DTOs.CategoryDTOs;
using API.DTOs.OrganizationDTOs;
using Domain.Entities.CategoryEntity;
using Domain.Entities.OrganizationEntity;
using Domain.Entities.OrganizationEntity.Interfaces;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/organizations")]
    public class OrganizationController(ILogger<OrganizationController> logger, IOrganizationService service) : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger = logger;
        private readonly IOrganizationService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Organization>>> GetAllOrganizationsAsync(CancellationToken cancellationToken)
        {
            List<Organization> organizations = await _service.GetAllOrganizationsAsync(cancellationToken);

            return Ok(organizations.Adapt<List<OrganizationGetDTO>>());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Organization?>> GetOrganizationByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            Organization? organization = await _service.GetOrganizationByIdAsync(id, cancellationToken);

            return Ok(organization.Adapt<OrganizationGetDTO>());
        }

        [HttpPost]
        public async Task<ActionResult<Organization?>> CreateOrganizationAsync([FromBody] OrganizationCreateDTO organizationCreateDTO, CancellationToken cancellationToken)
        {
            (Organization newOrganization, ValidationResult result) = Organization.CreateOrganization(Guid.NewGuid(), organizationCreateDTO.Name, organizationCreateDTO.Address, organizationCreateDTO.Description,
                                                                                                      organizationCreateDTO.CategoryId, organizationCreateDTO.TagIds);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.CreateOrganizationAsync(newOrganization, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrganizationAsync([FromRoute] Guid id, [FromBody] OrganizationCreateDTO organizationCreateDTO, CancellationToken cancellationToken)
        {
            (Organization newOrganization, ValidationResult result) = Organization.CreateOrganization(Guid.NewGuid(), organizationCreateDTO.Name, organizationCreateDTO.Address, organizationCreateDTO.Description,
                                                                                                      organizationCreateDTO.CategoryId, organizationCreateDTO.TagIds);

            if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            await _service.UpdateOrganizationAsync(id, newOrganization, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteOrganizationAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _service.DeleteOrganizationAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
