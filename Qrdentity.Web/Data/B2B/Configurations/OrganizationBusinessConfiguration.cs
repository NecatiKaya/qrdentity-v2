using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class OrganizationBusinessConfiguration : IEntityTypeConfiguration<OrganizationBusiness>
{
    public void Configure(EntityTypeBuilder<OrganizationBusiness> builder)
    {
        builder.ToTable("OrganizationBusinesses", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);

        builder.Property(model => model.OrganizationId).IsRequired();
        builder.Property(model => model.BusinessSubTypeId).IsRequired();
        builder.HasIndex(new string[] { "OrganizationId", "BusinessSubTypeId" },
            "Unique_Index_OrganizationId_SubType");

        TrackableEntityConfiguration.Apply(builder);
    }
}