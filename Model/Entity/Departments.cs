using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางเก็บข้อมูลหน่วยงาน/แผนก
/// </summary>
public partial class Departments
{
    /// <summary>
    /// รหัสแผนก (PK)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ชื่อแผนก เช่น ฝ่าย IT
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// สถานที่ตั้งของแผนก
    /// </summary>
    public string? Location { get; set; }

    public virtual ICollection<Assets> Assets { get; set; } = new List<Assets>();

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
