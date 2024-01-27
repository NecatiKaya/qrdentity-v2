using Microsoft.AspNetCore.Identity;

namespace Qrdentity.Auth.Data;

public sealed class QrdentityUser : IdentityUser<Guid>
{
    public Guid? OrganizationId { get; set; }

    public Guid? EnterpriseId { get; set; }
}