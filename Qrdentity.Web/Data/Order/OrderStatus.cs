namespace Qrdentity.Web.Data.Order;

public enum OrderStatus : int
{
    Initial = 1,
    Preparing = 2,
    WaitingForTransportation = 3,
    Transported = 4,
    ReceivedByCustomer = 5,
    ReturnedBack = 6,
    Cancelled = 7
}