using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TylorShop.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accounting> Accountings { get; set; }

    public virtual DbSet<CustomSetup> CustomSetups { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<DashboardDatum> DashboardData { get; set; }

    public virtual DbSet<Denial> Denials { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    public virtual DbSet<FileDatum> FileData { get; set; }

    public virtual DbSet<ModelDifference> ModelDifferences { get; set; }

    public virtual DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }

    public virtual DbSet<OrderTaking> OrderTakings { get; set; }

    public virtual DbSet<OrderTransaction> OrderTransactions { get; set; }

    public virtual DbSet<PermissionPolicyMemberPermissionsObject> PermissionPolicyMemberPermissionsObjects { get; set; }

    public virtual DbSet<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObjects { get; set; }

    public virtual DbSet<PermissionPolicyObjectPermissionsObject> PermissionPolicyObjectPermissionsObjects { get; set; }

    public virtual DbSet<PermissionPolicyRole> PermissionPolicyRoles { get; set; }

    public virtual DbSet<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObjects { get; set; }

    public virtual DbSet<PermissionPolicyUser> PermissionPolicyUsers { get; set; }

    public virtual DbSet<PermissionPolicyUserUsersPermissionPolicyRoleRole> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; }

    public virtual DbSet<PrimativeDataCenter> PrimativeDataCenters { get; set; }

    public virtual DbSet<ReportDataV2> ReportDataV2s { get; set; }

    public virtual DbSet<XpobjectType> XpobjectTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounting>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Accounting");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_Accounting");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_Accounting");

            entity.HasIndex(e => e.Owner, "iOwner_Accounting");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_Accounting");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AccountingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Accounting_CreatedBy");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.AccountingOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_Accounting_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AccountingUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Accounting_UpdatedBy");
        });

        modelBuilder.Entity<CustomSetup>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("CustomSetup");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_CustomSetup");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_CustomSetup");

            entity.HasIndex(e => e.Owner, "iOwner_CustomSetup");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_CustomSetup");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CustomSetupCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_CustomSetup_CreatedBy");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.CustomSetupOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_CustomSetup_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CustomSetupUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_CustomSetup_UpdatedBy");
        });

        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("CustomerInfo");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_CustomerInfo");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_CustomerInfo");

            entity.HasIndex(e => e.Owner, "iOwner_CustomerInfo");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_CustomerInfo");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Age).HasMaxLength(100);
            entity.Property(e => e.Body).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Gola).HasMaxLength(100);
            entity.Property(e => e.Hat).HasMaxLength(100);
            entity.Property(e => e.Lomba).HasMaxLength(100);
            entity.Property(e => e.LuzHata).HasMaxLength(100);
            entity.Property(e => e.Pet).HasMaxLength(100);
            entity.Property(e => e.Put).HasMaxLength(100);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CustomerInfoCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_CustomerInfo_CreatedBy");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.CustomerInfoOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_CustomerInfo_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CustomerInfoUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_CustomerInfo_UpdatedBy");
        });

        modelBuilder.Entity<DashboardDatum>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_DashboardData");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Denial>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Denial");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_Denial");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_Denial");

            entity.HasIndex(e => e.Owner, "iOwner_Denial");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_Denial");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.ClientName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DenialCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Denial_CreatedBy");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.DenialOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_Denial_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DenialUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Denial_UpdatedBy");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("EmployeeMaster");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContactAddress).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.PermanentAddress).HasMaxLength(100);

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.EmployeeMaster)
                .HasForeignKey<EmployeeMaster>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMaster_Oid");
        });

        modelBuilder.Entity<FileDatum>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_FileData");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(260);
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<ModelDifference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("ModelDifference");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_ModelDifference");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContextId).HasMaxLength(100);
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UserId).HasMaxLength(100);
        });

        modelBuilder.Entity<ModelDifferenceAspect>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("ModelDifferenceAspect");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_ModelDifferenceAspect");

            entity.HasIndex(e => e.Owner, "iOwner_ModelDifferenceAspect");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.ModelDifferenceAspects)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_ModelDifferenceAspect_Owner");
        });

        modelBuilder.Entity<OrderTaking>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("OrderTaking");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_OrderTaking");

            entity.HasIndex(e => e.Customer, "iCustomer_OrderTaking");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_OrderTaking");

            entity.HasIndex(e => e.Owner, "iOwner_OrderTaking");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_OrderTaking");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.Aligori).HasMaxLength(100);
            entity.Property(e => e.Body).HasMaxLength(100);
            entity.Property(e => e.CikonRabar).HasMaxLength(100);
            entity.Property(e => e.CouraRabar).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DelevaryDate).HasColumnType("datetime");
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Gola).HasMaxLength(100);
            entity.Property(e => e.Hat).HasMaxLength(100);
            entity.Property(e => e.Hata).HasMaxLength(100);
            entity.Property(e => e.Kolar).HasMaxLength(100);
            entity.Property(e => e.Lomba).HasMaxLength(100);
            entity.Property(e => e.LuzHata).HasMaxLength(100);
            entity.Property(e => e.MobilePocket).HasMaxLength(100);
            entity.Property(e => e.Nic).HasMaxLength(100);
            entity.Property(e => e.NicThekeFara).HasMaxLength(100);
            entity.Property(e => e.NocShohoFara).HasMaxLength(100);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Paipen).HasMaxLength(100);
            entity.Property(e => e.PantPocket).HasMaxLength(100);
            entity.Property(e => e.Pet).HasMaxLength(100);
            entity.Property(e => e.Plet).HasMaxLength(100);
            entity.Property(e => e.Pocket).HasMaxLength(100);
            entity.Property(e => e.PocketThekeBondo).HasMaxLength(100);
            entity.Property(e => e.Put).HasMaxLength(100);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderTakingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_OrderTaking_CreatedBy");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.OrderTakings)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK_OrderTaking_Customer");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.OrderTakingOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_OrderTaking_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.OrderTakingUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_OrderTaking_UpdatedBy");
        });

        modelBuilder.Entity<OrderTransaction>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_OrderTransactions");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_OrderTransactions");

            entity.HasIndex(e => e.Order, "iOrder_OrderTransactions");

            entity.HasIndex(e => e.Owner, "iOwner_OrderTransactions");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_OrderTransactions");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderTransactionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_OrderTransactions_CreatedBy");

            entity.HasOne(d => d.OrderNavigation).WithMany(p => p.OrderTransactions)
                .HasForeignKey(d => d.Order)
                .HasConstraintName("FK_OrderTransactions_Order");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.OrderTransactionOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_OrderTransactions_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.OrderTransactionUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_OrderTransactions_UpdatedBy");
        });

        modelBuilder.Entity<PermissionPolicyMemberPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyMemberPermissionsObject");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyMemberPermissionsObject");

            entity.HasIndex(e => e.TypePermissionObject, "iTypePermissionObject_PermissionPolicyMemberPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

            entity.HasOne(d => d.TypePermissionObjectNavigation).WithMany(p => p.PermissionPolicyMemberPermissionsObjects)
                .HasForeignKey(d => d.TypePermissionObject)
                .HasConstraintName("FK_PermissionPolicyMemberPermissionsObject_TypePermissionObject");
        });

        modelBuilder.Entity<PermissionPolicyNavigationPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyNavigationPermissionsObject");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyNavigationPermissionsObject");

            entity.HasIndex(e => e.Role, "iRole_PermissionPolicyNavigationPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.PermissionPolicyNavigationPermissionsObjects)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_PermissionPolicyNavigationPermissionsObject_Role");
        });

        modelBuilder.Entity<PermissionPolicyObjectPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyObjectPermissionsObject");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyObjectPermissionsObject");

            entity.HasIndex(e => e.TypePermissionObject, "iTypePermissionObject_PermissionPolicyObjectPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

            entity.HasOne(d => d.TypePermissionObjectNavigation).WithMany(p => p.PermissionPolicyObjectPermissionsObjects)
                .HasForeignKey(d => d.TypePermissionObject)
                .HasConstraintName("FK_PermissionPolicyObjectPermissionsObject_TypePermissionObject");
        });

        modelBuilder.Entity<PermissionPolicyRole>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyRole");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyRole");

            entity.HasIndex(e => e.ObjectType, "iObjectType_PermissionPolicyRole");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.PermissionPolicyRoles)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_PermissionPolicyRole_ObjectType");
        });

        modelBuilder.Entity<PermissionPolicyTypePermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyTypePermissionsObject");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyTypePermissionsObject");

            entity.HasIndex(e => e.Role, "iRole_PermissionPolicyTypePermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.PermissionPolicyTypePermissionsObjects)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_PermissionPolicyTypePermissionsObject_Role");
        });

        modelBuilder.Entity<PermissionPolicyUser>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyUser");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PermissionPolicyUser");

            entity.HasIndex(e => e.ObjectType, "iObjectType_PermissionPolicyUser");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.PermissionPolicyUsers)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_PermissionPolicyUser_ObjectType");
        });

        modelBuilder.Entity<PermissionPolicyUserUsersPermissionPolicyRoleRole>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            entity.HasIndex(e => new { e.Roles, e.Users }, "iRolesUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles").IsUnique();

            entity.HasIndex(e => e.Roles, "iRoles_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            entity.HasIndex(e => e.Users, "iUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            entity.Property(e => e.Oid)
                .ValueGeneratedNever()
                .HasColumnName("OID");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.PermissionPolicyUserUsersPermissionPolicyRoleRoles)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Roles");

            entity.HasOne(d => d.UsersNavigation).WithMany(p => p.PermissionPolicyUserUsersPermissionPolicyRoleRoles)
                .HasForeignKey(d => d.Users)
                .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Users");
        });

        modelBuilder.Entity<PrimativeDataCenter>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PrimativeDataCenter");

            entity.HasIndex(e => e.CreatedBy, "iCreatedBy_PrimativeDataCenter");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_PrimativeDataCenter");

            entity.HasIndex(e => e.Owner, "iOwner_PrimativeDataCenter");

            entity.HasIndex(e => e.UpdatedBy, "iUpdatedBy_PrimativeDataCenter");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.ActiovationDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DanialKstring)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("DanialKString");
            entity.Property(e => e.DanialString)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PrimativeDataCenterCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_PrimativeDataCenter_CreatedBy");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.PrimativeDataCenterOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_PrimativeDataCenter_Owner");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PrimativeDataCenterUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_PrimativeDataCenter_UpdatedBy");
        });

        modelBuilder.Entity<ReportDataV2>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("ReportDataV2");

            entity.HasIndex(e => e.Gcrecord, "iGCRecord_ReportDataV2");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ObjectTypeName).HasMaxLength(512);
            entity.Property(e => e.ParametersObjectTypeName).HasMaxLength(512);
            entity.Property(e => e.PredefinedReportType).HasMaxLength(512);
        });

        modelBuilder.Entity<XpobjectType>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("XPObjectType");

            entity.HasIndex(e => e.TypeName, "iTypeName_XPObjectType").IsUnique();

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.AssemblyName).HasMaxLength(254);
            entity.Property(e => e.TypeName).HasMaxLength(254);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
