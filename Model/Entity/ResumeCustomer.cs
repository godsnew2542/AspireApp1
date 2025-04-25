using System;
using System.Collections.Generic;

namespace Model.Entity;

/// <summary>
/// เก็บข้อมูลผู้ลงทะเบียนทั้งหมด
/// </summary>
public partial class ResumeCustomer
{
    /// <summary>
    /// เลขที่บัตรประชาชน
    /// </summary>
    public string CusPid { get; set; } = null!;

    /// <summary>
    /// ชื่อภาษาไทย
    /// </summary>
    public string CusNameTh { get; set; } = null!;

    /// <summary>
    /// ชื่อภาษาอังกฤษ
    /// </summary>
    public string? CusNameEn { get; set; }

    /// <summary>
    /// นามสกุลภาษาไทย
    /// </summary>
    public string CusSnameTh { get; set; } = null!;

    /// <summary>
    /// นามสกุลภาษาอังกฤษ
    /// </summary>
    public string? CusSnameEn { get; set; }

    /// <summary>
    /// รหัสคำนำหน้าชื่อ(01=นาย,02=นางสาว,03=นาง)
    /// </summary>
    public string? TitleId { get; set; }

    /// <summary>
    /// รหัสเพศ (1=ชาย,2=หญิง)
    /// </summary>
    public string? SexId { get; set; }

    /// <summary>
    /// วันเดือนปีเกิดอยู่ในรูป DDMMYYYY (Y=ปี พ.ศ.)
    /// </summary>
    public string? CusBirthDate { get; set; }

    /// <summary>
    /// รหัสจังหวัดที่เกิด
    /// </summary>
    public string? CusBirthProv { get; set; }

    /// <summary>
    /// กรุ๊ปเลือด
    /// </summary>
    public string? CusBloodGroup { get; set; }

    /// <summary>
    /// รหัสศาสนา 
    /// </summary>
    public string? ReligionId { get; set; }

    /// <summary>
    /// เชื้อชาติ
    /// </summary>
    public string? RaceId { get; set; }

    /// <summary>
    /// สัญชาติ
    /// </summary>
    public string? NationId { get; set; }

    /// <summary>
    /// เบอร์โทรศัพท์มือถือ 
    /// </summary>
    public string Mobile { get; set; } = null!;

    /// <summary>
    /// อีเมล
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// รหัสสถานะภาพสมรส 
    /// </summary>
    public string? MaritalStatus { get; set; }

    /// <summary>
    /// วันเดือนปีที่สมัครDDMMYYYY (Y=ปี พ.ศ.)
    /// </summary>
    public string RegistDate { get; set; } = null!;

    /// <summary>
    /// รหัสหน่วยงานที่รับเข้าทำงานแล้ว
    /// </summary>
    public string? RecruitedBy { get; set; }

    /// <summary>
    /// วันเดือนปีที่มีหน่วยงานรับเข้าทำงาน
    /// </summary>
    public string? RecruitedDate { get; set; }

    /// <summary>
    /// บุคคลอ้างอิง
    /// </summary>
    public string? RefPerson { get; set; }

    /// <summary>
    /// ตำแหน่งที่สนใจสมัคร
    /// </summary>
    public string? InterestPosition { get; set; }

    /// <summary>
    /// วันที่เวลาปรับปรุงข้อมูลล่าสุด
    /// </summary>
    public string? ModifiedDate { get; set; }

    public string Password { get; set; } = null!;

    /// <summary>
    /// 0 ไม่แผ่ยเแพร่ || 1 แผ่ยแพร่
    /// </summary>
    public string? PublicProfile { get; set; }

    public string? ImgFilePath { get; set; }

    public string? LectFlag { get; set; }

    public string? MajorSpecId { get; set; }

    public string? BirthCountry { get; set; }

    public string? MilitaryStatus { get; set; }

    public string? LecturerDate { get; set; }

    public string? PosLectId { get; set; }

    public string? ExpiredDate { get; set; }
}
