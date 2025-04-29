using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางประเภทของครุภัณฑ์
/// </summary>
public partial class AssetCategories
{
    /// <summary>
    /// รหัสประเภท
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ชื่อประเภท เช่น คอมพิวเตอร์
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// อัตราค่าเสื่อมราคา (% ต่อปี)
    /// </summary>
    public decimal? DepreciationRate { get; set; }

    public virtual ICollection<Assets> Assets { get; set; } = new List<Assets>();
}
