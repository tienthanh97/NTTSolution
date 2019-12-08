using NTT.Data.EntityModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTT.Data.EntityModel.PrototypeEntity
{
    public class Course : BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Display(Name = "Number")]
        //public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public long DepartmentID { get; set; }

       // public Department Department { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }
        //public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
