using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TylorShop.Models_Customs;

namespace TylorShop.Models;

public partial class OrderTaking
{
    public OrderTaking()
    {
        Amount = 0.0;
        
    }
    [DisplayName("অর্ডার নং")]
    public int Oid { get; set; }

    public Guid? Owner { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    [Required(ErrorMessage = "কাস্টমার আবশ্যক")]
    [DisplayName("কাস্টমার")]
    public int? Customer { get;set;}
    //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    [DisplayName("অর্ডার তারিখ")]
    public DateTime? OrderDate { get; set; }

    [Required(ErrorMessage = "ডেলিভারি তারিখ আবশ্যক।")]
    //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    [DisplayName("ডেলিভারি তারিখ")]
    public DateTime? DelevaryDate { get; set; }

    public string? Discription { get; set; }

    public string? DiscriptionPant { get; set; }

    public string? DiscriptionKamiz { get; set; }
    [DisplayName("একছাটা")]

    public int? EkChata { get; set; }
    [DisplayName("একছারা জুবা")]
    public int? EkCharaJubba { get; set; }
    [DisplayName("কাবলি")]
    public int? Kabli { get; set; }
    [DisplayName("শেরওয়ানি")]
    public int? Serwani { get; set; }
    [DisplayName("ফতুয়া")]
    public int? Fotua { get; set; }
    [DisplayName("জুব্বা কালিদার")]
    public int? JubbaKalidar { get; set; }
    [DisplayName("শার্ট")]
    public int? Shart { get; set; }
    [DisplayName("বোরকা")]
    public int? Borka { get; set; }
    [DisplayName("কটি")]
    public int? Koti { get; set; }
    [DisplayName("কালিদার")]
    public int? Kalider { get; set; }
    [DisplayName("আলগরি")]
    public string? Aligori { get; set; }
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
    [DisplayName("কলার")]
    public string? Kolar { get; set; }
    [DisplayName("প্লেট")]
    public string? Plet { get; set; }
    [DisplayName("হাতা")]

    public string? Hata { get; set; }

    [DisplayName("নিচ")]
    public string? Nic { get; set; }
    [DisplayName("নকসহ ফারা")]
    public string? NocShohoFara { get; set; }
    [DisplayName("নিচ থেকে ফারা")]
    public string? NicThekeFara { get; set; }
    [DisplayName("পকেট থেকে ফারা")]
    public string? PocketThekeBondo { get; set; }

    [DisplayName("পকেট")]
    public string? Pocket { get; set; }

    [DisplayName("পাইপেন")]
    public string? Paipen { get; set; }

    [DisplayName("সেলোয়ার")]
    public int? Selwar { get; set; }

    [DisplayName("চোস")]

    public int? Cosh { get; set; }
    [DisplayName("চুরিদার")]
    public int? Curidar { get; set; }

    [DisplayName("ন্যরো")]
    public int? Naro { get; set; }
    [DisplayName("প্যান্ট")]
    public int? Pant { get; set; }

    [DisplayName("প্যান্ট পকেট")]

    public string? PantPocket { get; set; }

    [DisplayName("চুরিদার")]
    public string? CouraRabar { get; set; }
    [DisplayName("চিকন রাবার")]
    public string? CikonRabar { get; set; }

    [DisplayName("মোবাইল পকেট")]
    public string? MobilePocket { get; set; }

    [DisplayName("প্রস্তুত?")]
    public bool? IsReady { get; set; }
    [DisplayName("ডেলিভারি?")]
    public bool? IsDelevered { get; set; }

    [DisplayName("বাতিল?")]
    public bool? IsCancelled { get; set; }

    [DisplayName("টাকার পরিমাণ")]
    public double? Amount { get; set; }

    [DisplayName("ছাড়")]
    public double? Discount { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? Gcrecord { get; set; }

    public virtual EmployeeMaster? CreatedByNavigation { get; set; }

    public virtual CustomerInfo? CustomerNavigation { get; set; }

    //[NotMapped]
    //public string CustomerName {  get; set; }
    ////$"{CustomerName} - {Email}";

    [NotMapped]
    [DisplayName("অগ্রিম টাকা")]
    public double? Advanced
    {
        get
        {
            return OrderTransactions?
                .Where(x => x.TransactionType == 1 && (x.IsActive ?? false))
                .Sum(x => (double?)x.Amount) ?? 0.0;
        }
    }
    [NotMapped]
    [DisplayName("পরিশোধিত টাকা")]
    public double? DuePaid
    {
        get
        {
            return OrderTransactions?
                .Where(x => x.TransactionType == 2 && (x.IsActive ?? false))
                .Sum(x => (double?)x.Amount) ?? 0.0;
        }
    }
    [NotMapped]
    [DisplayName("ফেরত টাকা")]
    public double? Refund
    {
        get
        {
            return OrderTransactions?
                .Where(x => x.TransactionType == 3 && (x.IsActive ?? false))
                .Sum(x => (double?)x.Amount) ?? 0.0;
        }
    }

    [NotMapped]
    [DisplayName("বাকী টাকা")]
    [NonNegative(ErrorMessage = "বাকী টাকা ০ এর কম হতে পারবে না।")]
    public double? Due
    {
        get
        {
            double amount = Amount ?? 0.0;
            double advanced = Advanced ?? 0.0;
            double duePaid = DuePaid ?? 0.0;
            double refund = Refund ?? 0.0;

            return amount -Discount- advanced - duePaid + refund;
        }
    }

    
    public virtual ICollection<OrderTransaction> OrderTransactions { get; set; } = new List<OrderTransaction>();

    public virtual EmployeeMaster? OwnerNavigation { get; set; }

    public virtual EmployeeMaster? UpdatedByNavigation { get; set; }
}
