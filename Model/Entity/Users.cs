using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางเก็บข้อมูลผู้ใช้งานระบบ
/// </summary>
public partial class Users
{
    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ชื่อเต็มของผู้ใช้งาน
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// อีเมล (ใช้ล็อกอิน)
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// อ้างอิงแผนกที่สังกัด
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// บทบาทการใช้งาน (admin, staff, auditor)
    /// </summary>
    public string? Role { get; set; }

    public virtual ICollection<Assets> Assets { get; set; } = new List<Assets>();

    public virtual Departments? Department { get; set; }

    public virtual ICollection<MaintenanceLogs> MaintenanceLogs { get; set; } = new List<MaintenanceLogs>();

    public virtual ICollection<SupplyRequests> SupplyRequests { get; set; } = new List<SupplyRequests>();

    public virtual ICollection<SupplyTransactions> SupplyTransactions { get; set; } = new List<SupplyTransactions>();
}
