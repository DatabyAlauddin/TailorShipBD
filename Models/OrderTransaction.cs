using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TylorShop.Models;

public partial class OrderTransaction
{
    public int Oid { get; set; }

    public Guid? Owner { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    [DisplayName("সচল?")]
    public bool? IsActive { get; set; }

    [NotMapped]
    public bool Active
    {
        get; 
        set ;
    }

    [DisplayName("অর্ডার নং")]
    public int? Order { get; set; }
    [DisplayName("টাকার পরিমাণ")]
    [Required(ErrorMessage = "টাকার পরিমাণ প্রদান করা আবশ্যক।")] // Amount is required
    [Range(0.01, double.MaxValue, ErrorMessage = "টাকার পরিমাণ অবশ্যই শূন্যের চেয়ে বড় হতে হবে।")] // Amount must be greater than 0
    public double? Amount { get; set; }
    [DisplayName("ট্রানজাকশন ধরণ")]
    
    public int? TransactionType { get; set; }

    [NotMapped]
    [DisplayName("ট্রানজাকশন ধরণ")]
    [Required(ErrorMessage = "ট্রানজাকশন ধরণ আবশ্যক")]
    public TransactionTypeEnum? TransactionTypeEnum
    {
        get => (TransactionTypeEnum?)TransactionType;
        set => TransactionType = (int?)value;
    }
    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public virtual EmployeeMaster? CreatedByNavigation { get; set; }

    public virtual OrderTaking? OrderNavigation { get; set; }

    public virtual EmployeeMaster? OwnerNavigation { get; set; }

    public virtual EmployeeMaster? UpdatedByNavigation { get; set; }

   
    
}

public enum TransactionTypeEnum
{
    Adnvaced = 1,
    Due = 2,
    Refund = 3,
    
}

