namespace NTT.Data.EntityModel.PrototypeEntity
{
    public class CourseAssignment: BaseEntity
    {
        public long InstructorID { get; set; }
        public long CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
