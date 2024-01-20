using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Common;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Order.Configuration;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder.Property(order => order.OrderSalePriceWithoutVatApplied).IsRequired();
        builder.Property(order => order.OrderSalePriceWithVatApplied).IsRequired();
        builder.Property(order => order.OrderNumber).IsRequired().IsUnicode(false).HasColumnType("varchar(15)");

        builder.HasOne(order => order.ShoppingCart)
            .WithOne(cart => cart.Order)
            .HasForeignKey<ShoppingCart>(cart => cart.OrderId)
            .IsRequired(false);

        builder.HasOne(o => o.BillingAddress).WithMany().HasForeignKey(o => o.BillingAddressId).IsRequired();
        builder.HasOne(o => o.ShipmentAddress).WithMany().HasForeignKey(o => o.ShipmentAddressId).IsRequired();

        builder.HasIndex(order => order.OrderNumber).IsUnique();

        TrackableEntityConfiguration.Apply(builder);
    }
}