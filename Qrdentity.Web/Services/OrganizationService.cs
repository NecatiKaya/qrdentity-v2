using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.B2B;

namespace Qrdentity.Web.Services;

public sealed class OrganizationService : IOrganizationService
{
    private readonly QrdentityContext _qrdentityContext;
    private readonly ILogger<OrganizationService> _logger;

    [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
    public OrganizationService(QrdentityContext qrdentityContext, ILogger<OrganizationService> logger)
    {
        _qrdentityContext = qrdentityContext;
        _logger = logger;
    }

    public async Task AddAsync(Organization organization, CancellationToken cancellationToken = default)
    {
        await _qrdentityContext.Organizations.AddAsync(organization, cancellationToken);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Organization?> GetByIdAsync(Guid organizationId, CancellationToken cancellationToken = default)
    {
        Organization? organization = await _qrdentityContext.Organizations
            .Include(company => company.Agreements)
            .Include(company => company.Contacts.Where(eachContact => eachContact.IsActive))
            .Include(company => company.Businesses.Where(businessArea => businessArea.IsActive))
            .ThenInclude(businessArea => businessArea.BusinessSubType)
            .ThenInclude(businessAreaSubCategoryEntity => businessAreaSubCategoryEntity.BusinessType)
            .Include(company => company.Address)
            .ThenInclude(address => address.District)
            .ThenInclude(district => district.City)
            .ThenInclude(city => city.Country)
            .Include(company => company.TaxOffice)
            .FirstOrDefaultAsync(
                company => company.Id == organizationId && company.IsActive,
                cancellationToken: cancellationToken);

        return organization;
    }

    public async Task<ContactInformation> AddContactToOrganization(Guid organizationId,
        ContactInformation contactInformation,
        CancellationToken cancellationToken = default)
    {
        Organization? organization = await GetByIdAsync(organizationId, cancellationToken);
        if (organization == null)
        {
            //TODO: replace with option pattern.
            throw new Exception("");
        }

        organization.Contacts.Add(contactInformation);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);
        return contactInformation;
    }

    public async Task<List<OrganizationBusiness>> UpdateBusinesses(Guid organizationId, List<Guid> businessesSubTypes,
        CancellationToken cancellationToken = default)
    {
        Organization? organization = await GetByIdAsync(organizationId, cancellationToken);
        if (organization == null)
        {
            //TODO: replace with option pattern.
            throw new Exception("");
        }

        foreach (OrganizationBusiness eachBusiness in organization.Businesses.ToList())
        {
            //TODO: maybe marking disabled is better for reporting. ie: organization business can be limited to a time period
            eachBusiness.IsActive = false;
            //organization.Businesses.Remove(eachBusiness);
        }

        //TODO: request may contain duplicate ids. So it is better to distinct by id so that we may prevent duplicate business sub types.
        List<BusinessSubType> availableBusinessSubTypes = await _qrdentityContext.BusinessSubTypes
            .Where(eachBusinessSubType => businessesSubTypes.Contains(eachBusinessSubType.Id))
            .ToListAsync(cancellationToken: cancellationToken);

        foreach (BusinessSubType eachBusinessSubType in availableBusinessSubTypes)
        {
            organization.Businesses.Add(new OrganizationBusiness
            {
                OrganizationId = organizationId,
                BusinessSubTypeId = eachBusinessSubType.Id,
                BusinessSubType = eachBusinessSubType,
                IsActive = true
            });
        }

        await _qrdentityContext.SaveChangesAsync(cancellationToken);
        return organization.Businesses.Where(eachBusiness => eachBusiness.IsActive).ToList();
    }

    public async Task<List<ContactInformation>> RemoveContacts(Guid organizationId, List<Guid> contactsToRemove,
        CancellationToken cancellationToken = default)
    {
        Organization? organization = await GetByIdAsync(organizationId, cancellationToken);
        if (organization == null)
        {
            //TODO: replace with option pattern.
            throw new Exception("");
        }

        // Update database immediately. If updated row count is not greater than zero than no contact is updated.
        int updatedRowCount = await _qrdentityContext.OrganizationContacts
            .Where(eachContact =>
                eachContact.OrganizationId == organizationId && contactsToRemove.Contains(eachContact.Id))
            .ExecuteUpdateAsync(contactInfo =>
                contactInfo.SetProperty(x => x.IsActive, false), cancellationToken: cancellationToken);

        //TODO: If no contact is updated, please log it to log server
        if (updatedRowCount <= 0)
        {
        }

        List<ContactInformation> contacts = organization.Contacts.ToList();
        return contacts;
    }

    public async Task<List<OrganizationAgreement>> AddAgreement(Guid organizationId, OrganizationAgreement agreement,
        CancellationToken cancellationToken = default)
    {
        DateTime nowDate = DateTime.UtcNow;
        OrganizationAgreement? activeAgreement = null;
        try
        {
            activeAgreement = await _qrdentityContext.OrganizationAgreements.Where(eachAgreement =>
                    eachAgreement.OrganizationId == organizationId && eachAgreement.AgreementStartDate <= nowDate &&
                    eachAgreement.AgreementEndDate >= nowDate && eachAgreement.IsActive)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            //TODO: fix exception and return option.
            //There are multiple active agreements for the given company. 
            throw new Exception("Can not have multiple active agreements");
        }

        if (activeAgreement != null)
        {
            if (agreement.AgreementStartDate <= activeAgreement.AgreementEndDate)
            {
                //TODO: fix with option
                throw new Exception("can not insert new agreement between active agreement period.");
            }
        }

        _qrdentityContext.OrganizationAgreements.Add(agreement);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);

        Organization? organization = await GetByIdAsync(organizationId, cancellationToken);
        return organization?.Agreements.ToList() ?? [];
    }

    public async Task<OrganizationAgreement> ToggleAgreementStatus(Guid organizationId, Guid agreementId,
        CancellationToken cancellationToken)
    {
        OrganizationAgreement? agreement = await _qrdentityContext.OrganizationAgreements.Where(eachAgreement =>
                eachAgreement.OrganizationId == organizationId &&
                eachAgreement.Id == agreementId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (agreement == null)
        {
            //TODO: Fix exception
            throw new Exception("Agreement not found");
        }

        if (agreement.IsActive)
        {
            agreement.IsActive = false;
        }
        else
        {
            DateTimeOffset nowDate = DateTimeOffset.Now.UtcDateTime;
            if (nowDate >= agreement.AgreementStartDate && nowDate <= agreement.AgreementEndDate)
            {
                agreement.IsActive = true;
            }
            else
            {
                throw new Exception(ErrorConstants.AgreementStatusCanNotBeActivated);
            }
        }

        await _qrdentityContext.SaveChangesAsync(cancellationToken);
        return agreement;
    }
}