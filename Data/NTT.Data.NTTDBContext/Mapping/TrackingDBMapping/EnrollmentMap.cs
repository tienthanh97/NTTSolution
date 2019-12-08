using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.PrototypeEntity;

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    [DBContext(Name = "PrototypeDBContext")]
    public class EnrollmentMap : TrackingSystemEntityTypeConfiguration<Enrollment>
    {
        public override void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
        }
    }
}
