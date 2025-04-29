using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.Entity;

public partial class DbModelContext : DbContext
{
    public DbModelContext(DbContextOptions<DbModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetCategories> AssetCategories { get; set; }

    public virtual DbSet<Assets> Assets { get; set; }

    public virtual DbSet<Departments> Departments { get; set; }

    public virtual DbSet<MaintenanceLogs> MaintenanceLogs { get; set; }

    public virtual DbSet<Supplies> Supplies { get; set; }

    public virtual DbSet<SupplyRequestItems> SupplyRequestItems { get; set; }

    public virtual DbSet<SupplyRequests> SupplyRequests { get; set; }

    public virtual DbSet<SupplyTransactions> SupplyTransactions { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetCategories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asset_categories_pkey");

            entity.ToTable("asset_categories", "training", tb => tb.HasComment("ตารางประเภทของครุภัณฑ์"));

            entity.Property(e => e.Id)
                .HasComment("รหัสประเภท")
                .HasColumnName("id");
            entity.Property(e => e.DepreciationRate)
                .HasPrecision(5, 2)
                .HasComment("อัตราค่าเสื่อมราคา (% ต่อปี)")
                .HasColumnName("depreciation_rate");
            entity.Property(e => e.Name)
                .HasComment("ชื่อประเภท เช่น คอมพิวเตอร์")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Assets>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assets_pkey");

            entity.ToTable("assets", "training", tb => tb.HasComment("ตารางเก็บข้อมูลครุภัณฑ์"));

            entity.HasIndex(e => e.AssetCode, "assets_asset_code_key").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("รหัสครุภัณฑ์")
                .HasColumnName("id");
            entity.Property(e => e.AssetCode)
                .HasComment("หมายเลขครุภัณฑ์ (รหัสทรัพย์สิน)")
                .HasColumnName("asset_code");
            entity.Property(e => e.CategoryId)
                .HasComment("อ้างอิงประเภทครุภัณฑ์")
                .HasColumnName("category_id");
            entity.Property(e => e.CurrentValue)
                .HasPrecision(12, 2)
                .HasComment("มูลค่าปัจจุบัน (หลังค่าเสื่อม)")
                .HasColumnName("current_value");
            entity.Property(e => e.DepartmentId)
                .HasComment("หน่วยงานผู้ถือครอง")
                .HasColumnName("department_id");
            entity.Property(e => e.Location)
                .HasComment("ตำแหน่งที่จัดเก็บ")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasComment("ชื่อครุภัณฑ์")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasComment("ราคาจัดซื้อ")
                .HasColumnName("price");
            entity.Property(e => e.PurchaseDate)
                .HasComment("วันที่จัดซื้อ")
                .HasColumnName("purchase_date");
            entity.Property(e => e.Status)
                .HasComment("สถานะของครุภัณฑ์")
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasComment("ผู้รับผิดชอบครุภัณฑ์")
                .HasColumnName("user_id");
            entity.Property(e => e.WarrantyExpiry)
                .HasComment("วันหมดประกัน")
                .HasColumnName("warranty_expiry");

            entity.HasOne(d => d.Category).WithMany(p => p.Assets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("assets_category_id_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.Assets)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("assets_department_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Assets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("assets_user_id_fkey");
        });

        modelBuilder.Entity<Departments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments", "training", tb => tb.HasComment("ตารางเก็บข้อมูลหน่วยงาน/แผนก"));

            entity.Property(e => e.Id)
                .HasComment("รหัสแผนก (PK)")
                .HasColumnName("id");
            entity.Property(e => e.Location)
                .HasComment("สถานที่ตั้งของแผนก")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasComment("ชื่อแผนก เช่น ฝ่าย IT")
                .HasColumnName("name");
        });

        modelBuilder.Entity<MaintenanceLogs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("maintenance_logs_pkey");

            entity.ToTable("maintenance_logs", "training", tb => tb.HasComment("ตารางบันทึกประวัติการซ่อมครุภัณฑ์"));

            entity.Property(e => e.Id)
                .HasComment("รหัสรายการซ่อม")
                .HasColumnName("id");
            entity.Property(e => e.AssetId)
                .HasComment("อ้างอิงครุภัณฑ์ที่ซ่อม")
                .HasColumnName("asset_id");
            entity.Property(e => e.Cost)
                .HasPrecision(12, 2)
                .HasComment("ค่าซ่อม")
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasComment("รายละเอียดการซ่อม")
                .HasColumnName("description");
            entity.Property(e => e.RepairDate)
                .HasComment("วันที่ซ่อม")
                .HasColumnName("repair_date");
            entity.Property(e => e.ReportedBy)
                .HasComment("ผู้แจ้งซ่อม")
                .HasColumnName("reported_by");
            entity.Property(e => e.Status)
                .HasComment("สถานะการซ่อม")
                .HasColumnName("status");

            entity.HasOne(d => d.Asset).WithMany(p => p.MaintenanceLogs)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("maintenance_logs_asset_id_fkey");

            entity.HasOne(d => d.ReportedByNavigation).WithMany(p => p.MaintenanceLogs)
                .HasForeignKey(d => d.ReportedBy)
                .HasConstraintName("maintenance_logs_reported_by_fkey");
        });

        modelBuilder.Entity<Supplies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplies_pkey");

            entity.ToTable("supplies", "training", tb => tb.HasComment("ตารางเก็บรายการพัสดุสิ้นเปลือง"));

            entity.Property(e => e.Id)
                .HasComment("รหัสพัสดุ")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasComment("ชื่อพัสดุ")
                .HasColumnName("name");
            entity.Property(e => e.ReorderPoint)
                .HasDefaultValue(10)
                .HasComment("ระดับแจ้งเตือนสั่งซื้อใหม่")
                .HasColumnName("reorder_point");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasComment("จำนวนคงเหลือ")
                .HasColumnName("stock_quantity");
            entity.Property(e => e.Unit)
                .HasComment("หน่วยนับ เช่น ชิ้น, กล่อง")
                .HasColumnName("unit");
        });

        modelBuilder.Entity<SupplyRequestItems>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supply_request_items_pkey");

            entity.ToTable("supply_request_items", "training", tb => tb.HasComment("รายการพัสดุที่แนบในใบเบิก"));

            entity.Property(e => e.Id)
                .HasComment("รหัสรายการ")
                .HasColumnName("id");
            entity.Property(e => e.Quantity)
                .HasComment("จำนวนที่ขอเบิก")
                .HasColumnName("quantity");
            entity.Property(e => e.RequestId)
                .HasComment("อ้างอิงใบเบิก")
                .HasColumnName("request_id");
            entity.Property(e => e.SupplyId)
                .HasComment("พัสดุที่ขอเบิก")
                .HasColumnName("supply_id");

            entity.HasOne(d => d.Request).WithMany(p => p.SupplyRequestItems)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("supply_request_items_request_id_fkey");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyRequestItems)
                .HasForeignKey(d => d.SupplyId)
                .HasConstraintName("supply_request_items_supply_id_fkey");
        });

        modelBuilder.Entity<SupplyRequests>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supply_requests_pkey");

            entity.ToTable("supply_requests", "training", tb => tb.HasComment("ตารางเก็บใบขอเบิกพัสดุ"));

            entity.Property(e => e.Id)
                .HasComment("รหัสใบขอเบิก")
                .HasColumnName("id");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasComment("วันที่ขอเบิก")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestedBy)
                .HasComment("ผู้ขอเบิก")
                .HasColumnName("requested_by");
            entity.Property(e => e.Status)
                .HasComment("สถานะใบเบิก")
                .HasColumnName("status");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.SupplyRequests)
                .HasForeignKey(d => d.RequestedBy)
                .HasConstraintName("supply_requests_requested_by_fkey");
        });

        modelBuilder.Entity<SupplyTransactions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supply_transactions_pkey");

            entity.ToTable("supply_transactions", "training", tb => tb.HasComment("บันทึกการรับ/จ่ายพัสดุ"));

            entity.Property(e => e.Id)
                .HasComment("รหัสรายการ")
                .HasColumnName("id");
            entity.Property(e => e.PerformedBy)
                .HasComment("ผู้ดำเนินการ")
                .HasColumnName("performed_by");
            entity.Property(e => e.Quantity)
                .HasComment("จำนวนที่รับ/จ่าย")
                .HasColumnName("quantity");
            entity.Property(e => e.Reference)
                .HasComment("อ้างอิง เช่น เลขใบเบิกหรือสั่งซื้อ")
                .HasColumnName("reference");
            entity.Property(e => e.SupplyId)
                .HasComment("พัสดุที่มีการเคลื่อนไหว")
                .HasColumnName("supply_id");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasComment("วันที่ทำรายการ")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasComment("ประเภท: in (รับ), out (จ่าย)")
                .HasColumnName("transaction_type");

            entity.HasOne(d => d.PerformedByNavigation).WithMany(p => p.SupplyTransactions)
                .HasForeignKey(d => d.PerformedBy)
                .HasConstraintName("supply_transactions_performed_by_fkey");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyTransactions)
                .HasForeignKey(d => d.SupplyId)
                .HasConstraintName("supply_transactions_supply_id_fkey");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "training", tb => tb.HasComment("ตารางเก็บข้อมูลผู้ใช้งานระบบ"));

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("รหัสผู้ใช้งาน")
                .HasColumnName("id");
            entity.Property(e => e.DepartmentId)
                .HasComment("อ้างอิงแผนกที่สังกัด")
                .HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasComment("อีเมล (ใช้ล็อกอิน)")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasComment("ชื่อเต็มของผู้ใช้งาน")
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasComment("บทบาทการใช้งาน (admin, staff, auditor)")
                .HasColumnName("role");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("users_department_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
