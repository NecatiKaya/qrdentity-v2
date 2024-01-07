using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.B2B.Configurations;

internal sealed class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
{
    public void Configure(EntityTypeBuilder<ContactInformation> builder)
    {
        builder.ToTable("Contacts", DataConstants.B2BSchemaName);
        builder.HasKey(table => table.Id);
        builder.Property(model => model.OrganizationId).IsRequired();
        builder.Property(model => model.Name).IsRequired().HasColumnType("varchar(30)");
        builder.Property(model => model.Surname).IsRequired().HasColumnType("varchar(30)");
        builder.Property(model => model.Email).IsRequired().HasColumnType("varchar(50)");
        builder.Property(model => model.PhoneNumber).IsRequired().HasColumnType("varchar(20)");

        TrackableEntityConfiguration.Apply(builder);
    }
}