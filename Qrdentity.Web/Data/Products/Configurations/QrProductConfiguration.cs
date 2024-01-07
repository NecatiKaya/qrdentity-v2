using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Products.Configurations;

internal sealed class QrProductConfiguration : IEntityTypeConfiguration<QrProduct>
{
    public void Configure(EntityTypeBuilder<QrProduct> builder)
    {
        builder.ToTable("Products", DataConstants.ProductSchema);
        builder.HasKey(table => table.Id);

        builder.Property(product => product.Name).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired()
            .IsUnicode();
        builder.Property(product => product.Descriptions).HasColumnType("text").HasMaxLength(1000).IsRequired()
            .IsUnicode();
        builder.Property(product => product.ListPriceWithoutVatApplied).IsRequired();
        builder.Property(product => product.SalePriceWithoutVatApplied).IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}