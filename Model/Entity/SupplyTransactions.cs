using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// บันทึกการรับ/จ่ายพัสดุ
/// </summary>
public partial class SupplyTransactions
{
    /// <summary>
    /// รหัสรายการ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// พัสดุที่มีการเคลื่อนไหว
    /// </summary>
    public int? SupplyId { get; set; }

    /// <summary>
    /// ประเภท: in (รับ), out (จ่าย)
    /// </summary>
    public string? TransactionType { get; set; }

    /// <summary>
    /// จำนวนที่รับ/จ่าย
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// วันที่ทำรายการ
    /// </summary>
    public DateOnly? TransactionDate { get; set; }

    /// <summary>
    /// ผู้ดำเนินการ
    /// </summary>
    public int? PerformedBy { get; set; }

    /// <summary>
    /// อ้างอิง เช่น เลขใบเบิกหรือสั่งซื้อ
    /// </summary>
    public string? Reference { get; set; }

    public virtual Users? PerformedByNavigation { get; set; }

    public virtual Supplies? Supply { get; set; }
}
