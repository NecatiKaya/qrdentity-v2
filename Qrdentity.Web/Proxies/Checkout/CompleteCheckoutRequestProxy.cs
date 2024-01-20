namespace Qrdentity.Web.Proxies.Checkout;

public sealed class CompleteCheckoutRequestProxy
{
    public CompleteCheckoutRequestProxy(Guid billingAddressId, Guid shipmentAddressId)
    {
        if (billingAddressId == Guid.Empty)
        {
            //TODO
            throw new Exception("");
        }

        if (shipmentAddressId == Guid.Empty)
        {
            //TODO
            throw new Exception("");
        }

        BillingAddressId = billingAddressId;
        ShipmentAddressId = shipmentAddressId;
    }

    public Guid BillingAddressId { get; }

    public Guid ShipmentAddressId { get; }
}