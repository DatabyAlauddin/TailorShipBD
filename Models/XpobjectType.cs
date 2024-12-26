using System;
using System.Collections.Generic;

namespace TylorShop.Models;

public partial class XpobjectType
{
    public int Oid { get; set; }

    public string? TypeName { get; set; }

    public string? AssemblyName { get; set; }

    public virtual ICollection<PermissionPolicyRole> PermissionPolicyRoles { get; set; } = new List<PermissionPolicyRole>();

    public virtual ICollection<PermissionPolicyUser> PermissionPolicyUsers { get; set; } = new List<PermissionPolicyUser>();
}
