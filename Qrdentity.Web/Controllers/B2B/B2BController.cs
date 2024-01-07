using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Qrdentity.Web.Data.B2B;
using Qrdentity.Web.Mapping;
using Qrdentity.Web.Proxies.Common;
using Qrdentity.Web.Proxies.Organization;
using Qrdentity.Web.Services;

namespace Qrdentity.Web.Controllers.B2B;

[ApiController]
[Route("api/v1/b2b/organizations")]
public class B2BController : B2BControllerBase
{
    private readonly IOrganizationService _organizationService;
    private readonly ILogger<B2BController> _logger;

    [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
    public B2BController(IOrganizationService organizationService, ILogger<B2BController> logger)
    {
        _organizationService = organizationService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] SaveOrganizationRequestProxy proxy,
        CancellationToken cancellationToken)
    {
        Organization organization = OrganizationMapping.CreateOrganization(proxy);
        await _organizationService.AddAsync(organization, cancellationToken);

        organization = (await _organizationService.GetByIdAsync(organization.Id, cancellationToken))!;
        GetOrganizationByIdResponseProxy organizationProxy = OrganizationMapping.CreateOrganizationProxy(organization);
        return Ok(organizationProxy);
    }

    [HttpGet("{organizationId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid organizationId, CancellationToken cancellationToken)
    {
        Organization? organization = await _organizationService.GetByIdAsync(organizationId, cancellationToken);
        if (organization == null)
        {
            return NotFound();
        }

        GetOrganizationByIdResponseProxy organizationProxy = OrganizationMapping.CreateOrganizationProxy(organization);
        return Ok(organizationProxy);
    }

    [HttpPut("{organizationId:guid}/contacts")]
    public async Task<IActionResult> AddContact([FromRoute] Guid organizationId,
        [FromBody] SaveContactInformationRequestProxy proxy, CancellationToken cancellationToken)
    {
        ContactInformation contactInformation = OrganizationMapping.CreateContactInformation(organizationId, proxy);
        await _organizationService.AddContactToOrganization(organizationId, contactInformation, cancellationToken);

        //TODO: maybe it will be good to fetch organization contact again from database.
        GetOrganizationContactResponseProxy contactProxy =
            OrganizationMapping.CreateContactResponseProxy(contactInformation);
        return Ok(contactProxy);
    }

    [HttpPost("{organizationId:guid}/businesses")]
    public async Task<IActionResult> UpdateBusinesses([FromRoute] Guid organizationId,
        [FromBody] List<Guid> businesses, CancellationToken cancellationToken)
    {
        List<OrganizationBusiness> organizationBusinesses =
            await _organizationService.UpdateBusinesses(organizationId, businesses, cancellationToken);

        List<GetOrganizationBusinessProxyResponse> businessProxyResponses =
            organizationBusinesses.Select(OrganizationMapping.CreateOrganizationBusinessProxyResponse).ToList();

        return Ok(businessProxyResponses);
    }

    [HttpDelete("{organizationId:guid}/contacts")]
    public async Task<IActionResult> RemoveContact([FromRoute] Guid organizationId,
        [FromBody] List<Guid> contactsToRemove, CancellationToken cancellationToken)
    {
        List<ContactInformation> availableContacts =
            await _organizationService.RemoveContacts(organizationId, contactsToRemove, cancellationToken);

        List<GetOrganizationContactResponseProxy> availableProxies =
            availableContacts.Select(OrganizationMapping.CreateContactResponseProxy).ToList();
        return Ok(availableProxies);
    }

    [HttpPut("{organizationId:guid}/agreements")]
    public async Task<IActionResult> AddAgreement([FromRoute] Guid organizationId,
        [FromBody] SaveOrganizationAgreementRequestProxy proxy, CancellationToken cancellationToken)
    {
        OrganizationAgreement agreementToAdd = OrganizationMapping.CreateAgreement(proxy, organizationId);
        List<OrganizationAgreement> agreements =
            await _organizationService.AddAgreement(organizationId, agreementToAdd, cancellationToken);

        List<GetOrganizationAgreementResponseProxy> agreementResponseProxies =
            agreements.Select(OrganizationMapping.CreateOrganizationAgreementResponseProxy).ToList();
        return Ok(agreementResponseProxies);
    }

    [HttpPatch("{organizationId:guid}/agreements/{agreementId:guid}")]
    public async Task<IActionResult> ToggleAgreementStatus([FromRoute] Guid organizationId,
        [FromRoute] Guid agreementId, CancellationToken cancellationToken)
    {
        OrganizationAgreement agreement =
            await _organizationService.ToggleAgreementStatus(organizationId, agreementId, cancellationToken);
        GetOrganizationAgreementResponseProxy agreementResponseProxy =
            OrganizationMapping.CreateOrganizationAgreementResponseProxy(agreement);
        return Ok(agreementResponseProxy);
    }
}