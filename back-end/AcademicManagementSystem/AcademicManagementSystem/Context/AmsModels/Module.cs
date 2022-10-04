using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicManagementSystem.Context.AmsModels;

[Table("module")]
public class Module
{
    // constructor
    public Module()
    {
        this.CourseModuleSemesters = new HashSet<CourseModuleSemester>();
    }
    
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("center_id")]
    public int CenterId { get; set; }
    
    [Column("semester_name_portal")]
    [StringLength(255)]
    public string SemesterNamePortal { get; set; }
    
    [Column("module_name")]
    [StringLength(255)]
    public string ModuleName { get; set; }
    
    [Column("module_exam_name_portal")]
    [StringLength(255)]
    public string ModuleExamNamePortal { get; set; }
    
    [Column("module_type")]
    [StringLength(100)]
    public string ModuleType { get; set; }
    
    [Column("max_theory_grade")]
    public int? MaxTheoryGrade { get; set; }
    
    [Column("max_practical_grade")]
    public int? MaxPracticalGrade { get; set; }
    
    [Column("hours")]
    public int Hours { get; set; }
    
    [Column("days")]
    public int Days { get; set; }
    
    [Column("exam_type")]
    [StringLength(100)]
    public string ExamType { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    // relationships
    public virtual Center Center { get; set; }
    public virtual ICollection<CourseModuleSemester> CourseModuleSemesters { get; set; }
}