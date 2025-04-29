using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางบันทึกประวัติการซ่อมครุภัณฑ์
/// </summary>
public partial class MaintenanceLogs
{
    /// <summary>
    /// รหัสรายการซ่อม
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// อ้างอิงครุภัณฑ์ที่ซ่อม
    /// </summary>
    public int? AssetId { get; set; }

    /// <summary>
    /// ผู้แจ้งซ่อม
    /// </summary>
    public int? ReportedBy { get; set; }

    /// <summary>
    /// รายละเอียดการซ่อม
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// วันที่ซ่อม
    /// </summary>
    public DateOnly? RepairDate { get; set; }

    /// <summary>
    /// ค่าซ่อม
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// สถานะการซ่อม
    /// </summary>
    public string? Status { get; set; }

    public virtual Assets? Asset { get; set; }

    public virtual Users? ReportedByNavigation { get; set; }
}
