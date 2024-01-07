using Qrdentity.Web.Data.B2B;
using Qrdentity.Web.Proxies.Common;
using Qrdentity.Web.Proxies.Organization;

namespace Qrdentity.Web.Mapping;

public static class OrganizationMapping
{
    public static Organization CreateOrganization(SaveOrganizationRequestProxy proxy)
    {
        Organization organization = new Organization();
        organization.LongName = proxy.LongName;
        organization.ShortName = proxy.ShortName;
        organization.Alias = proxy.Alias;
        organization.EmployeeCount = proxy.EmployeeCount;
        organization.TaxOfficeId = proxy.TaxOfficeId;
        organization.TaxNumber = proxy.TaxNumber;

        OrganizationAgreement agreement = new OrganizationAgreement();
        agreement.FileExtension = proxy.Agreement.FileExtension;
        agreement.FileLength = proxy.Agreement.FileLength;
        agreement.FileName = proxy.Agreement.FileName;
        agreement.AgreementStartDate = proxy.Agreement.AgreementStartDate;
        agreement.AgreementEndDate = proxy.Agreement.AgreementEndDate;
        organization.Agreements.Add(agreement);

        OrganizationAddress address = new OrganizationAddress();
        address.Address = proxy.Address.Address;
        address.DistrictId = proxy.Address.DistrictId;
        address.Latitude = proxy.Address.Latitude;
        address.Longitude = proxy.Address.Longitude;
        address.ZipCode = proxy.Address.ZipCode;
        address.GoogleMapsLink = proxy.Address.GoogleMapsLink;
        organization.Address = address;

        foreach (SaveContactInformationRequestProxy eachContact in proxy.Contacts)
        {
            ContactInformation contactInformation = new ContactInformation();
            contactInformation.Email = eachContact.Email;
            contactInformation.Name = eachContact.Name;
            contactInformation.Surname = eachContact.Surname;
            contactInformation.PhoneNumber = eachContact.PhoneNumber;
            organization.Contacts.Add(contactInformation);
        }

        foreach (Guid eachBusinessSubType in proxy.BusinessSubTypes)
        {
            organization.Businesses.Add(new OrganizationBusiness()
            {
                BusinessSubTypeId = eachBusinessSubType
            });
        }

        return organization;
    }

    public static GetOrganizationByIdResponseProxy CreateOrganizationProxy(Organization organization)
    {
        GetOrganizationByIdResponseProxy organizationProxy = new GetOrganizationByIdResponseProxy
        {
            Id = organization.Id,
            ShortName = organization.ShortName,
            LongName = organization.LongName,
            Alias = organization.Alias,
            EmployeeCount = organization.EmployeeCount,
            TaxOfficeId = organization.TaxOfficeId,
            TaxNumber = organization.TaxNumber
        };
        organizationProxy.Address = CreateAddressResponseProxy(organization.Address);
        organizationProxy.Agreements?.AddRange(
            organization.Agreements.Select(CreateOrganizationAgreementResponseProxy));
        organizationProxy.Contacts?.AddRange(organization.Contacts.Select(CreateContactResponseProxy));
        organizationProxy.Businesses.AddRange(
            organization.Businesses.Select(CreateOrganizationBusinessSubTypeResponseProxy));
        return organizationProxy;
    }

    public static ContactInformation CreateContactInformation(Guid organizationId,
        SaveContactInformationRequestProxy proxy)
    {
        return new ContactInformation
        {
            OrganizationId = organizationId,
            Name = proxy.Name,
            Surname = proxy.Surname,
            Email = proxy.Email,
            PhoneNumber = proxy.PhoneNumber
        };
    }

    public static GetOrganizationAddressResponseProxy CreateAddressResponseProxy(OrganizationAddress address)
    {
        GetOrganizationAddressResponseProxy proxy = new GetOrganizationAddressResponseProxy();
        proxy.Id = address.Id;
        proxy.Address = address.Address;
        proxy.Longitude = address.Longitude;
        proxy.Latitude = address.Latitude;
        proxy.GoogleMapsLink = address.GoogleMapsLink;
        proxy.City = address.District.City.Name;
        proxy.Country = address.District.City.Country.Name;
        proxy.District = address.District.Name;
        proxy.ZipCode = address.ZipCode;
        return proxy;
    }

    public static GetOrganizationAgreementResponseProxy CreateOrganizationAgreementResponseProxy(
        OrganizationAgreement agreement)
    {
        return new GetOrganizationAgreementResponseProxy
        {
            Id = agreement.Id,
            FileName = agreement.FileName,
            FileExtension = agreement.FileExtension,
            FileLength = agreement.FileLength,
            AgreementStartDate = agreement.AgreementStartDate,
            AgreementEndDate = agreement.AgreementEndDate,
            IsActive = agreement.IsActive
        };
    }

    public static GetOrganizationContactResponseProxy CreateContactResponseProxy(ContactInformation contactInformation)
    {
        return new GetOrganizationContactResponseProxy
        {
            Id = contactInformation.Id,
            Name = contactInformation.Name,
            Surname = contactInformation.Surname,
            Email = contactInformation.Email,
            PhoneNumber = contactInformation.PhoneNumber
        };
    }

    public static GetOrganizationBusinessSubTypeResponseProxy CreateOrganizationBusinessSubTypeResponseProxy(
        OrganizationBusiness business)
    {
        return new GetOrganizationBusinessSubTypeResponseProxy
        {
            Id = business.Id,
            Name = business.BusinessSubType.Name,
            Descriptions = business.BusinessSubType.Descriptions,
            BusinessTypeId = business.BusinessSubType.BusinessType.Id,
            BusinessTypeName = business.BusinessSubType.BusinessType.Name,
            BusinessTypeDescriptions = business.BusinessSubType.BusinessType.Descriptions
        };
    }

    public static GetOrganizationBusinessProxyResponse CreateOrganizationBusinessProxyResponse(
        OrganizationBusiness business)
    {
        GetOrganizationBusinessProxyResponse response = new GetOrganizationBusinessProxyResponse
        {
            Id = business.Id,
            BusinessTypeId = business.BusinessSubType.BusinessType.Id,
            BusinessTypeName = business.BusinessSubType.BusinessType.Name,
            BusinessTypeDescriptions = business.BusinessSubType.BusinessType.Descriptions,
            BusinessSubTypeId = business.BusinessSubType.Id,
            BusinessSubTypeName = business.BusinessSubType.Name,
            BusinessSubTypeDescriptions = business.BusinessSubType.Descriptions,
        };
        return response;
    }

    public static OrganizationAgreement CreateAgreement(SaveOrganizationAgreementRequestProxy proxy,
        Guid organizationId)
    {
        return new OrganizationAgreement
        {
            OrganizationId = organizationId,
            FileName = proxy.FileName,
            FileExtension = proxy.FileExtension,
            FileLength = proxy.FileLength,
            AgreementStartDate = proxy.AgreementStartDate,
            AgreementEndDate = proxy.AgreementEndDate,
            IsActive = true
        };
    }
}