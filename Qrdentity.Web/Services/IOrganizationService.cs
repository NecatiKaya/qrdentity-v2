using Qrdentity.Web.Data.B2B;

namespace Qrdentity.Web.Services;

public interface IOrganizationService
{
    Task AddAsync(Organization organization, CancellationToken cancellationToken = default);

    Task<Organization?> GetByIdAsync(Guid organizationId, CancellationToken cancellationToken = default);

    Task<ContactInformation> AddContactToOrganization(Guid organizationId, ContactInformation contactInformation,
        CancellationToken cancellationToken = default);

    Task<List<OrganizationBusiness>> UpdateBusinesses(Guid organizationId, List<Guid> businessesSubTypes,
        CancellationToken cancellationToken = default);

    Task<List<ContactInformation>> RemoveContacts(Guid organizationId, List<Guid> contactsToRemove,
        CancellationToken cancellationToken = default);

    Task<List<OrganizationAgreement>> AddAgreement(Guid organizationId, OrganizationAgreement agreement,
        CancellationToken cancellationToken = default);

    Task<OrganizationAgreement> ToggleAgreementStatus(Guid organizationId, Guid agreementId, CancellationToken cancellationToken = default);
}