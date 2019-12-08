using System.ComponentModel.DataAnnotations;

namespace NTT.Data.EntityModel.PrototypeEntity
{

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment: BaseEntity
    {
        //public int EnrollmentID { get; set; }
        public long CourseID { get; set; }
        public long StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }

}
