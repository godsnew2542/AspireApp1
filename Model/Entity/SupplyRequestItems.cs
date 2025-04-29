using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// รายการพัสดุที่แนบในใบเบิก
/// </summary>
public partial class SupplyRequestItems
{
    /// <summary>
    /// รหัสรายการ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// อ้างอิงใบเบิก
    /// </summary>
    public int? RequestId { get; set; }

    /// <summary>
    /// พัสดุที่ขอเบิก
    /// </summary>
    public int? SupplyId { get; set; }

    /// <summary>
    /// จำนวนที่ขอเบิก
    /// </summary>
    public int Quantity { get; set; }

    public virtual SupplyRequests? Request { get; set; }

    public virtual Supplies? Supply { get; set; }
}
