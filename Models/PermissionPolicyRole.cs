using System;
using System.Collections.Generic;

namespace TylorShop.Models;

public partial class PermissionPolicyRole
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public bool? IsAdministrative { get; set; }

    public bool? CanEditModel { get; set; }

    public int? PermissionPolicy { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual XpobjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObjects { get; set; } = new List<PermissionPolicyNavigationPermissionsObject>();

    public virtual ICollection<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObjects { get; set; } = new List<PermissionPolicyTypePermissionsObject>();

    public virtual ICollection<PermissionPolicyUserUsersPermissionPolicyRoleRole> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; } = new List<PermissionPolicyUserUsersPermissionPolicyRoleRole>();
}
