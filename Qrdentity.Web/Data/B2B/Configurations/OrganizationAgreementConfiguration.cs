using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class OrganizationAgreementConfiguration : IEntityTypeConfiguration<OrganizationAgreement>
{
    public void Configure(EntityTypeBuilder<OrganizationAgreement> builder)
    {
        builder.ToTable("OrganizationAgreements", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);
        builder.Property(model => model.OrganizationId).IsRequired();
        builder.Property(model => model.AgreementStartDate).IsRequired();
        builder.Property(model => model.AgreementEndDate).IsRequired();
        builder.Property(model => model.FileName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(model => model.FileExtension).IsRequired().HasColumnType("varchar(5)");
        builder.Property(model => model.FileLength).IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}