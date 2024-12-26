using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.Build.Framework;
using TylorShop.Models_Customs;

namespace TylorShop.Models;

public partial class CustomerInfo
{
    
    public int Oid { get; set; }

    public Guid? Owner { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }
    
    [DisplayName("নাম")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "নাম ফিল্ড আবশ্যক।")]
    public string? CustomerName { get; set; }
    [DisplayName("মোবাইল নাম্বার")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "কন্টাক্ট নম্বর ফিল্ড আবশ্যক।")]
    [RegularExpression(@"^\d+$", ErrorMessage = "কন্টাক্ট নম্বর শুধু ডিজিট থাকতে হবে।")]
    public string? ContactNumber { get; set; }

    [NotMapped]
    public string DisplayText => $"{CustomerName} | {ContactNumber}";

    //[DisplayName("লিঙ্গ")]
    public int? Gender { get; set; }

    [NotMapped]
    [DisplayName("লিঙ্গ")]
    public GenderEnum? GenderEnum
    {
        get => (GenderEnum?)Gender;
        set => Gender = (int?)value;
    }

    [DisplayName("বয়স")]
    
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Age must be a decimal number with up to two decimal places.")]
    public string? Age { get; set; }

    [DisplayName("ঠিকানা")]
    public string? Address { get; set; }
    [DisplayName("লম্বা")]
    public string? Lomba { get; set; }
    [DisplayName("বডি")]
    public string? Body { get; set; }
    [DisplayName("পেট")]
    public string? Pet { get; set; }
    [DisplayName("পুট")]
    public string? Put { get; set; }
    [DisplayName("হাত")]
    public string? Hat { get; set; }
    [DisplayName("গলা")]
    public string? Gola { get; set; }
    [DisplayName("লুজ হাতা")]
    public string? LuzHata { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public virtual EmployeeMaster? CreatedByNavigation { get; set; }

    public virtual ICollection<OrderTaking> OrderTakings { get; set; } = new List<OrderTaking>();

    public virtual EmployeeMaster? OwnerNavigation { get; set; }

    public virtual EmployeeMaster? UpdatedByNavigation { get; set; }
}

public enum GenderEnum
{
  
    পুরুষ = 1,
    
    মহিলা = 2,
    
    অন্যান্য = 3

}