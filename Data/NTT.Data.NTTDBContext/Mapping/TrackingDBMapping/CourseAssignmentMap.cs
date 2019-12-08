
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.PrototypeEntity;

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    [DBContext(Name = "PrototypeDBContext")]
    public class CourseAssignmentMap : TrackingSystemEntityTypeConfiguration<CourseAssignment>
    {
        public override void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment");
            builder.HasKey(c => new { c.CourseID, c.InstructorID });
            builder.Ignore(x => x.Id);
        }
    }
}
