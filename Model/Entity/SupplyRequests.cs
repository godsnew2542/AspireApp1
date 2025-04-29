using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// ตารางเก็บใบขอเบิกพัสดุ
/// </summary>
public partial class SupplyRequests
{
    /// <summary>
    /// รหัสใบขอเบิก
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ผู้ขอเบิก
    /// </summary>
    public int? RequestedBy { get; set; }

    /// <summary>
    /// วันที่ขอเบิก
    /// </summary>
    public DateOnly? RequestDate { get; set; }

    /// <summary>
    /// สถานะใบเบิก
    /// </summary>
    public string? Status { get; set; }

    public virtual Users? RequestedByNavigation { get; set; }

    public virtual ICollection<SupplyRequestItems> SupplyRequestItems { get; set; } = new List<SupplyRequestItems>();
}
