using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Data;

namespace Qrdentity.Web.Services;

public sealed class UserAddressService : IUserAddressService
{
    private readonly QrdentityContext _qrdentityContext;

    public UserAddressService(QrdentityContext qrdentityContext)
    {
        _qrdentityContext = qrdentityContext;
    }

    public async Task ValidateUserAddressAsync(Guid userId, Guid[] addresses,
        CancellationToken cancellationToken = default)
    {
        bool allAddressesBelongToGivenUser = await _qrdentityContext.UserAddresses.AllAsync(eachAddress =>
            addresses.Contains(eachAddress.Id) && eachAddress.IsActive, cancellationToken: cancellationToken);
        if (!allAddressesBelongToGivenUser)
        {
            //TODO
            throw new Exception("");
        }
    }
}