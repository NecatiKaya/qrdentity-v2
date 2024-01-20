namespace Qrdentity.Web.Services;

public interface IUserAddressService
{
    Task ValidateUserAddressAsync(Guid userId, Guid[] addresses, CancellationToken cancellationToken = default);
}