using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางเก็บรายการพัสดุสิ้นเปลือง
/// </summary>
public partial class Supplies
{
    /// <summary>
    /// รหัสพัสดุ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ชื่อพัสดุ
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// หน่วยนับ เช่น ชิ้น, กล่อง
    /// </summary>
    public string Unit { get; set; } = null!;

    /// <summary>
    /// จำนวนคงเหลือ
    /// </summary>
    public int? StockQuantity { get; set; }

    /// <summary>
    /// ระดับแจ้งเตือนสั่งซื้อใหม่
    /// </summary>
    public int? ReorderPoint { get; set; }

    public virtual ICollection<SupplyRequestItems> SupplyRequestItems { get; set; } = new List<SupplyRequestItems>();

    public virtual ICollection<SupplyTransactions> SupplyTransactions { get; set; } = new List<SupplyTransactions>();
}
