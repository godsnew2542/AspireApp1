using Microsoft.EntityFrameworkCore;

namespace Model.Entity;

public partial class DbModelContext : DbContext
{
    public DbModelContext(DbContextOptions<DbModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ResumeCustomer> ResumeCustomer { get; set; }

    public virtual DbSet<ResumeGradHis> ResumeGradHis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("oracle_fdw")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("postgres_fdw")
            .HasPostgresExtension("system_stats")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<ResumeCustomer>(entity =>
        {
            entity.HasKey(e => e.CusPid).HasName("resume_customer_pkey");

            entity.ToTable("resume_customer", "resume", tb => tb.HasComment("เก็บข้อมูลผู้ลงทะเบียนทั้งหมด"));

            entity.Property(e => e.CusPid)
                .HasMaxLength(26)
                .HasComment("เลขที่บัตรประชาชน")
                .HasColumnName("cus_pid");
            entity.Property(e => e.BirthCountry)
                .HasMaxLength(10)
                .HasColumnName("birth_country");
            entity.Property(e => e.CusBirthDate)
                .HasMaxLength(16)
                .HasComment("วันเดือนปีเกิดอยู่ในรูป DDMMYYYY (Y=ปี พ.ศ.)")
                .HasColumnName("cus_birth_date");
            entity.Property(e => e.CusBirthProv)
                .HasMaxLength(4)
                .HasComment("รหัสจังหวัดที่เกิด")
                .HasColumnName("cus_birth_prov");
            entity.Property(e => e.CusBloodGroup)
                .HasMaxLength(40)
                .HasComment("กรุ๊ปเลือด")
                .HasColumnName("cus_blood_group");
            entity.Property(e => e.CusNameEn)
                .HasMaxLength(90)
                .HasComment("ชื่อภาษาอังกฤษ")
                .HasColumnName("cus_name_en");
            entity.Property(e => e.CusNameTh)
                .HasMaxLength(80)
                .HasComment("ชื่อภาษาไทย")
                .HasColumnName("cus_name_th");
            entity.Property(e => e.CusSnameEn)
                .HasMaxLength(90)
                .HasComment("นามสกุลภาษาอังกฤษ")
                .HasColumnName("cus_sname_en");
            entity.Property(e => e.CusSnameTh)
                .HasMaxLength(80)
                .HasComment("นามสกุลภาษาไทย")
                .HasColumnName("cus_sname_th");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasComment("อีเมล")
                .HasColumnName("email");
            entity.Property(e => e.ExpiredDate)
                .HasMaxLength(16)
                .HasColumnName("expired_date");
            entity.Property(e => e.ImgFilePath)
                .HasMaxLength(200)
                .HasColumnName("img_file_path");
            entity.Property(e => e.InterestPosition)
                .HasMaxLength(40)
                .HasComment("ตำแหน่งที่สนใจสมัคร")
                .HasColumnName("interest_position");
            entity.Property(e => e.LectFlag)
                .HasMaxLength(20)
                .HasColumnName("lect_flag");
            entity.Property(e => e.LecturerDate)
                .HasMaxLength(16)
                .HasColumnName("lecturer_date");
            entity.Property(e => e.MajorSpecId)
                .HasMaxLength(40)
                .HasColumnName("major_spec_id");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(2)
                .HasComment("รหัสสถานะภาพสมรส ")
                .HasColumnName("marital_status");
            entity.Property(e => e.MilitaryStatus)
                .HasMaxLength(2)
                .HasColumnName("military_status");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasComment("เบอร์โทรศัพท์มือถือ ")
                .HasColumnName("mobile");
            entity.Property(e => e.ModifiedDate)
                .HasMaxLength(16)
                .HasComment("วันที่เวลาปรับปรุงข้อมูลล่าสุด")
                .HasColumnName("modified_date");
            entity.Property(e => e.NationId)
                .HasMaxLength(6)
                .HasComment("สัญชาติ")
                .HasColumnName("nation_id");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.PosLectId)
                .HasMaxLength(20)
                .HasColumnName("pos_lect_id");
            entity.Property(e => e.PublicProfile)
                .HasMaxLength(2)
                .HasComment("0 ไม่แผ่ยเแพร่ || 1 แผ่ยแพร่")
                .HasColumnName("public_profile");
            entity.Property(e => e.RaceId)
                .HasMaxLength(4)
                .HasComment("เชื้อชาติ")
                .HasColumnName("race_id");
            entity.Property(e => e.RecruitedBy)
                .HasMaxLength(4)
                .HasComment("รหัสหน่วยงานที่รับเข้าทำงานแล้ว")
                .HasColumnName("recruited_by");
            entity.Property(e => e.RecruitedDate)
                .HasMaxLength(16)
                .HasComment("วันเดือนปีที่มีหน่วยงานรับเข้าทำงาน")
                .HasColumnName("recruited_date");
            entity.Property(e => e.RefPerson)
                .HasMaxLength(2000)
                .HasComment("บุคคลอ้างอิง")
                .HasColumnName("ref_person");
            entity.Property(e => e.RegistDate)
                .HasMaxLength(16)
                .HasComment("วันเดือนปีที่สมัครDDMMYYYY (Y=ปี พ.ศ.)")
                .HasColumnName("regist_date");
            entity.Property(e => e.ReligionId)
                .HasMaxLength(2)
                .HasComment("รหัสศาสนา ")
                .HasColumnName("religion_id");
            entity.Property(e => e.SexId)
                .HasMaxLength(2)
                .HasComment("รหัสเพศ (1=ชาย,2=หญิง)")
                .HasColumnName("sex_id");
            entity.Property(e => e.TitleId)
                .HasMaxLength(2)
                .HasComment("รหัสคำนำหน้าชื่อ(01=นาย,02=นางสาว,03=นาง)")
                .HasColumnName("title_id");
        });

        modelBuilder.Entity<ResumeGradHis>(entity =>
        {
            entity.HasKey(e => e.GradHisId).HasName("resume_grad_his_pkey");

            entity.ToTable("resume_grad_his", "resume", tb => tb.HasComment("เก็บข้อมูลประวัติการศึกษา"));

            entity.Property(e => e.GradHisId)
                .HasDefaultValueSql("nextval('resume.\"SEQ_GRAD_HIS\"'::regclass)")
                .HasColumnName("grad_his_id");
            entity.Property(e => e.AdmissionYear)
                .HasMaxLength(8)
                .HasComment("ปีที่เริ่มการศึกษา")
                .HasColumnName("admission_year");
            entity.Property(e => e.CollegeId)
                .HasMaxLength(140)
                .HasColumnName("college_id");
            entity.Property(e => e.CountryGrad)
                .HasMaxLength(6)
                .HasComment("ประเทศที่จบการศึกษา")
                .HasColumnName("country_grad");
            entity.Property(e => e.CusPid)
                .HasMaxLength(26)
                .HasColumnName("cus_pid");
            entity.Property(e => e.DegreeId)
                .HasMaxLength(14)
                .HasColumnName("degree_id");
            entity.Property(e => e.Gpa)
                .HasPrecision(6, 2)
                .HasComment("เกรดเฉลี่ย")
                .HasColumnName("gpa");
            entity.Property(e => e.GradId)
                .HasMaxLength(14)
                .HasColumnName("grad_id");
            entity.Property(e => e.GradNo)
                .HasMaxLength(28)
                .HasDefaultValueSql("'0'::character varying")
                .HasColumnName("grad_no");
            entity.Property(e => e.GraduateYear)
                .HasMaxLength(8)
                .HasComment("ปีที่จบการศึกษา")
                .HasColumnName("graduate_year");
            entity.Property(e => e.Honor)
                .HasMaxLength(400)
                .HasComment("เกียรตินิยม")
                .HasColumnName("honor");
            entity.Property(e => e.MajorId)
                .HasMaxLength(10)
                .HasColumnName("major_id");
            entity.Property(e => e.Scholarship)
                .HasMaxLength(2000)
                .HasComment("ทุนการศึกษา")
                .HasColumnName("scholarship");
            entity.Property(e => e.UnivId)
                .HasMaxLength(8)
                .HasComment("รหัสมหาวิทยาลัย")
                .HasColumnName("univ_id");
        });
        modelBuilder.HasSequence("announce_id_seq", "dss_person65")
            .StartsAt(7L)
            .HasMin(0L);
        modelBuilder.HasSequence("c_seq", "central").StartsAt(21L);
        modelBuilder.HasSequence("camp_id", "central");
        modelBuilder.HasSequence("check_admin_id_seq", "dss_person65")
            .StartsAt(7L)
            .HasMin(0L);
        modelBuilder.HasSequence("chess_saveid", "central");
        modelBuilder.HasSequence("custid", "central").StartsAt(109L);
        modelBuilder.HasSequence("evt_notify_seq", "central");
        modelBuilder.HasSequence("evt_operators_seq", "central");
        modelBuilder.HasSequence("evt_profile_seq", "central").StartsAt(21L);
        modelBuilder.HasSequence("his_other_attatch_file_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_campus_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_contact_person_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_department_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_department_related_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_faculty_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_position_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_other_related_person_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_psu_caontact_person_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_psu_department_related_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_signed_activity_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_signed_detail_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_signed_project_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("his_university_his_id_seq", "mou").HasMax(2147483647L);
        modelBuilder.HasSequence("l_addr_id_seq", "dss_person65")
            .StartsAt(1363L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_child_id_seq", "dss_person65")
            .StartsAt(2187L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_family_id_seq", "dss_person65")
            .StartsAt(1450L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_nw_id_seq", "dss_person65")
            .StartsAt(3181L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_profile_id_seq", "dss_person65")
            .StartsAt(3L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_pvd_id_seq", "dss_person65")
            .StartsAt(1241L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_staff_id_seq", "dss_person65")
            .StartsAt(2478L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_staff_work_id_seq", "dss_person65")
            .StartsAt(810L)
            .HasMin(0L);
        modelBuilder.HasSequence("l_view_id_seq", "dss_person65")
            .StartsAt(44761L)
            .HasMin(0L);
        modelBuilder.HasSequence("nx_job_id", "central").HasMin(500L);
        modelBuilder.HasSequence("nx_lock_id", "central").HasMin(500L);
        modelBuilder.HasSequence("nx_log_line_id", "central").HasMin(500L);
        modelBuilder.HasSequence("nx_node_id", "central").HasMin(500L);
        modelBuilder.HasSequence("nx_term_id", "central").HasMin(500L);
        modelBuilder.HasSequence("nx_tree_id", "central").HasMin(500L);
        modelBuilder.HasSequence("ordid", "central").StartsAt(622L);
        modelBuilder.HasSequence("prodid", "central").StartsAt(200381L);
        modelBuilder.HasSequence("resign_id_seq", "dss_person65")
            .StartsAt(2L)
            .HasMin(0L);
        modelBuilder.HasSequence("SEQ_CHILD_DATA", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_CUS_ADDRESS", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_CUS_APPLY_ATTACH", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_FILE_ATTACH_REF", "resume")
            .StartsAt(53099L)
            .HasMin(0L)
            .HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_GRAD_HIS", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_JOB_APPLY", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_JOB_PUBLIC", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_JOB_VIEWER", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_lang_skill", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_LECT_ATT_REF", "resume")
            .StartsAt(322L)
            .HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_LECT_GRAD_HIS", "resume")
            .StartsAt(561L)
            .HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_LECT_PROFILE", "resume")
            .StartsAt(272L)
            .HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_LECT_WORK_HIS", "resume")
            .StartsAt(190L)
            .HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_OTHER_SKILL", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_PRIVACY_CONSENT", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("SEQ_PUBLIC_ATTACH_REF", "resume").HasMax(9999999999999999L);
        modelBuilder.HasSequence("seq_staff_notwork", "dss_person65")
            .StartsAt(101520L)
            .HasMin(0L);
        modelBuilder.HasSequence("seq_staff_notwork_permit", "dss_person65")
            .StartsAt(2270L)
            .HasMin(0L);
        modelBuilder.HasSequence("SEQ_WORK_HIS", "resume").HasMax(999999999999999999L);
        modelBuilder.HasSequence("smp_job_id_", "central")
            .HasMax(99999999L)
            .IsCyclic();
        modelBuilder.HasSequence("smp_service_seq", "central").StartsAt(16640L);
        modelBuilder.HasSequence("sq_ds_change_id_dept", "central")
            .StartsAt(949L)
            .HasMin(0L);
        modelBuilder.HasSequence("sq_ds_change_id_fac", "central").StartsAt(407L);
        modelBuilder.HasSequence("sq_ds_delete_dept", "central")
            .StartsAt(5L)
            .HasMin(0L);
        modelBuilder.HasSequence("sq_ds_delete_fac", "central").StartsAt(24L);
        modelBuilder.HasSequence("sq_ds_move_dept", "central")
            .StartsAt(6L)
            .HasMin(0L);
        modelBuilder.HasSequence("sq_ds_move_fac", "central").StartsAt(14L);
        modelBuilder.HasSequence("sq_ds_new_dept", "central").StartsAt(1260L);
        modelBuilder.HasSequence("sq_ds_new_fac", "central").StartsAt(614L);
        modelBuilder.HasSequence("w_right_run_no_seq", "dss_person65");
        modelBuilder.HasSequence("w_right_seq", "dss_person65")
            .StartsAt(4996L)
            .HasMin(0L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
