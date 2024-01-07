using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;
using Qrdentity.Web.Data.Products;

namespace Qrdentity.Web.Data.Cart.Configurations;

internal sealed class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItems", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder
            .HasOne<QrProduct>(cartItem => cartItem.Product)
            .WithMany(product => product.ShoppingCartItems)
            .HasForeignKey(cartItem => cartItem.ProductId)
            .IsRequired();
        
        builder.Property(shoppingCartItem => shoppingCartItem.ListPriceWithoutVatApplied).IsRequired();
        builder.Property(shoppingCartItem => shoppingCartItem.SalePriceWithoutVatApplied).IsRequired();
        
        TrackableEntityConfiguration.Apply(builder);
    }
}