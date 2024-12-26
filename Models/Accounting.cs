using System;
using System.Collections.Generic;

namespace TylorShop.Models;

public partial class Accounting
{
    public int Oid { get; set; }

    public Guid? Owner { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public double? Amount { get; set; }

    public int? AccountingType { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public virtual EmployeeMaster? CreatedByNavigation { get; set; }

    public virtual EmployeeMaster? OwnerNavigation { get; set; }

    public virtual EmployeeMaster? UpdatedByNavigation { get; set; }
}
