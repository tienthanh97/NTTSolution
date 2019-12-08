using System.ComponentModel.DataAnnotations;

namespace NTT.Data.EntityModel.PrototypeEntity
{
    public class OfficeAssignment : BaseEntity
    {
        [Key]
        public long InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
