using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.Cart.Configurations;

internal sealed class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCarts", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);
        
        builder.HasMany(cart => cart.ShoppingCartItems)
            .WithOne(cartItem => cartItem.ShoppingCart)
            .HasForeignKey(cartItem => cartItem.ShoppingCartId)
            .IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}