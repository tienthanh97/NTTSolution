


namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NTT.Data.EntityModel.PrototypeEntity;
    using NTT.Data.NTTDBContext;
    using NTT.Data.NTTDBContext.Mapping;

    [DBContext(Name = "PrototypeDBContext")]
    public class OfficeAssignmentMap : TrackingSystemEntityTypeConfiguration<OfficeAssignment>
    {
        public override void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment");
            builder.Ignore(x => x.Id);
        }
    }
}
