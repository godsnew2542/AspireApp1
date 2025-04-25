using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// เก็บข้อมูลประวัติการศึกษา
/// </summary>
public partial class ResumeGradHis
{
    public string CusPid { get; set; } = null!;

    public string DegreeId { get; set; } = null!;

    public string? MajorId { get; set; }

    /// <summary>
    /// รหัสมหาวิทยาลัย
    /// </summary>
    public string? UnivId { get; set; }

    /// <summary>
    /// ประเทศที่จบการศึกษา
    /// </summary>
    public string? CountryGrad { get; set; }

    /// <summary>
    /// ปีที่เริ่มการศึกษา
    /// </summary>
    public string? AdmissionYear { get; set; }

    /// <summary>
    /// ปีที่จบการศึกษา
    /// </summary>
    public string? GraduateYear { get; set; }

    /// <summary>
    /// ทุนการศึกษา
    /// </summary>
    public string? Scholarship { get; set; }

    /// <summary>
    /// เกรดเฉลี่ย
    /// </summary>
    public decimal Gpa { get; set; }

    /// <summary>
    /// เกียรตินิยม
    /// </summary>
    public string? Honor { get; set; }

    public string? GradId { get; set; }

    public string GradNo { get; set; } = null!;

    public string? CollegeId { get; set; }

    public double GradHisId { get; set; }
}
