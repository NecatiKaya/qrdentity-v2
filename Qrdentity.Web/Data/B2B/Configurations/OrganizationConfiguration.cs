using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;
using Qrdentity.Web.Data.Utility;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);
        builder
            .HasOne(company => company.Address)
            .WithOne(address => address.Organization)
            .HasForeignKey<OrganizationAddress>(address => address.OrganizationId)
            .IsRequired();
        builder
            .HasMany(company => company.Agreements)
            .WithOne(agreement => agreement.Organization)
            .HasForeignKey(agreement => agreement.OrganizationId)
            .IsRequired();
        builder
            .HasMany(organization => organization.Businesses)
            .WithOne(businessArea => businessArea.Organization)
            .HasForeignKey(businessArea => businessArea.OrganizationId)
            .IsRequired();
        builder
            .HasMany(company => company.Contacts)
            .WithOne(contact => contact.Company)
            .HasForeignKey(contact => contact.OrganizationId)
            .IsRequired();
        builder.HasOne<TaxOffice>(organization => organization.TaxOffice);
        builder.Property(model => model.LongName).HasColumnType("varchar(150)").IsRequired();
        builder.Property(model => model.Alias).HasColumnType("varchar(30)").IsRequired();
        builder.Property(model => model.ShortName).HasColumnType("varchar(50)").IsRequired();
        builder.Property(model => model.EmployeeCount).IsRequired(false);
        builder.Property(model => model.TaxNumber).HasColumnType("varchar(30)").IsRequired();
        builder.Property(model => model.TaxOfficeId).IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}