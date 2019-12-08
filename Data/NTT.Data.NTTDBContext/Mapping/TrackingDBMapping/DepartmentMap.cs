namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NTT.Data.EntityModel.PrototypeEntity;

    [DBContext(Name = "PrototypeDBContext")]
    public class DepartmentMap : TrackingSystemEntityTypeConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            
        }
    }
}
