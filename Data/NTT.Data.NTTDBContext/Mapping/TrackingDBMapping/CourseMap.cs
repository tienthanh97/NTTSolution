
namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NTT.Data.EntityModel.PrototypeEntity;

    [DBContext(Name = "PrototypeDBContext")]
    public partial class CourseMap : TrackingSystemEntityTypeConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
        }
    }
}
