using System;
using System.Collections.Generic;

namespace TylorShop.Models;

public partial class EmployeeMaster
{
    public Guid Oid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? ContactNumber { get; set; }

    public string? ContactAddress { get; set; }

    public string? PermanentAddress { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual ICollection<Accounting> AccountingCreatedByNavigations { get; set; } = new List<Accounting>();

    public virtual ICollection<Accounting> AccountingOwnerNavigations { get; set; } = new List<Accounting>();

    public virtual ICollection<Accounting> AccountingUpdatedByNavigations { get; set; } = new List<Accounting>();

    public virtual ICollection<CustomSetup> CustomSetupCreatedByNavigations { get; set; } = new List<CustomSetup>();

    public virtual ICollection<CustomSetup> CustomSetupOwnerNavigations { get; set; } = new List<CustomSetup>();

    public virtual ICollection<CustomSetup> CustomSetupUpdatedByNavigations { get; set; } = new List<CustomSetup>();

    public virtual ICollection<CustomerInfo> CustomerInfoCreatedByNavigations { get; set; } = new List<CustomerInfo>();

    public virtual ICollection<CustomerInfo> CustomerInfoOwnerNavigations { get; set; } = new List<CustomerInfo>();

    public virtual ICollection<CustomerInfo> CustomerInfoUpdatedByNavigations { get; set; } = new List<CustomerInfo>();

    public virtual ICollection<Denial> DenialCreatedByNavigations { get; set; } = new List<Denial>();

    public virtual ICollection<Denial> DenialOwnerNavigations { get; set; } = new List<Denial>();

    public virtual ICollection<Denial> DenialUpdatedByNavigations { get; set; } = new List<Denial>();

    public virtual PermissionPolicyUser OidNavigation { get; set; } = null!;

    public virtual ICollection<OrderTaking> OrderTakingCreatedByNavigations { get; set; } = new List<OrderTaking>();

    public virtual ICollection<OrderTaking> OrderTakingOwnerNavigations { get; set; } = new List<OrderTaking>();

    public virtual ICollection<OrderTaking> OrderTakingUpdatedByNavigations { get; set; } = new List<OrderTaking>();

    public virtual ICollection<OrderTransaction> OrderTransactionCreatedByNavigations { get; set; } = new List<OrderTransaction>();

    public virtual ICollection<OrderTransaction> OrderTransactionOwnerNavigations { get; set; } = new List<OrderTransaction>();

    public virtual ICollection<OrderTransaction> OrderTransactionUpdatedByNavigations { get; set; } = new List<OrderTransaction>();

    public virtual ICollection<PrimativeDataCenter> PrimativeDataCenterCreatedByNavigations { get; set; } = new List<PrimativeDataCenter>();

    public virtual ICollection<PrimativeDataCenter> PrimativeDataCenterOwnerNavigations { get; set; } = new List<PrimativeDataCenter>();

    public virtual ICollection<PrimativeDataCenter> PrimativeDataCenterUpdatedByNavigations { get; set; } = new List<PrimativeDataCenter>();
}
