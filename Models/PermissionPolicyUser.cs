using System;
using System.Collections.Generic;

namespace TylorShop.Models;

public partial class PermissionPolicyUser
{
    public Guid Oid { get; set; }

    public string? StoredPassword { get; set; }

    public bool? ChangePasswordOnFirstLogon { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual EmployeeMaster? EmployeeMaster { get; set; }

    public virtual XpobjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<PermissionPolicyUserUsersPermissionPolicyRoleRole> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; } = new List<PermissionPolicyUserUsersPermissionPolicyRoleRole>();
}
