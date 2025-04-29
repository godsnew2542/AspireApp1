using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางเก็บข้อมูลครุภัณฑ์
/// </summary>
public partial class Assets
{
    /// <summary>
    /// รหัสครุภัณฑ์
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// หมายเลขครุภัณฑ์ (รหัสทรัพย์สิน)
    /// </summary>
    public string AssetCode { get; set; } = null!;

    /// <summary>
    /// ชื่อครุภัณฑ์
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// อ้างอิงประเภทครุภัณฑ์
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// วันที่จัดซื้อ
    /// </summary>
    public DateOnly? PurchaseDate { get; set; }

    /// <summary>
    /// ราคาจัดซื้อ
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// มูลค่าปัจจุบัน (หลังค่าเสื่อม)
    /// </summary>
    public decimal? CurrentValue { get; set; }

    /// <summary>
    /// สถานะของครุภัณฑ์
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// ตำแหน่งที่จัดเก็บ
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// หน่วยงานผู้ถือครอง
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// ผู้รับผิดชอบครุภัณฑ์
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// วันหมดประกัน
    /// </summary>
    public DateOnly? WarrantyExpiry { get; set; }

    public virtual AssetCategories? Category { get; set; }

    public virtual Departments? Department { get; set; }

    public virtual ICollection<MaintenanceLogs> MaintenanceLogs { get; set; } = new List<MaintenanceLogs>();

    public virtual Users? User { get; set; }
}
